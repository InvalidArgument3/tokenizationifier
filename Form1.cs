using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace tokenizationifier
{
    public partial class Form1 : Form
    {
        private readonly string tempOutput = "temp_concatenated.txt";
        private readonly string outputFileName = "minified_output.txt";
        private string outputDirectory;
        private int fileCount = 0;
        private int errors = 0;
        private readonly List<string> fileBucket = new List<string>();

        public Form1()
        {
            InitializeComponent();
            SetupDragDrop();
            outputDirectory = Application.StartupPath;
            UpdateFileList();
            UpdateOpenOutputButton();
            modeComboBox.Items.AddRange(new[] { "CSMin (Package)", "Basic Whitespace Remover" });
            modeComboBox.SelectedIndex = 0;
            this.MinimumSize = new Size(600, 450);
        }

        private void SetupDragDrop()
        {
            textBox1.AllowDrop = true;
            textBox1.DragEnter += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
            };
            textBox1.DragDrop += (s, e) =>
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                AddFilesToBucket(files);
            };
        }

        private void AddFilesToBucket(string[] files)
        {
            var textFiles = files.Where(f => IsTextFile(f)).ToList();
            if (textFiles.Count == 0)
            {
                Log("No valid text files selected.");
                return;
            }

            foreach (var file in textFiles)
            {
                if (!fileBucket.Contains(file))
                {
                    fileBucket.Add(file);
                    Log($"Added: {file}");
                }
                else
                {
                    Log($"Skipped duplicate: {file}");
                }
            }
            UpdateFileList();
        }

        private void UpdateFileList()
        {
            textBox1.Clear();
            Log($"Output directory: {outputDirectory}");

            if (fileBucket.Count == 0)
            {
                Log("No files in bucket. Add files to minify.");
                return;
            }

            Log($"Files in bucket ({fileBucket.Count}):");
            int totalTokens = 0;

            foreach (var file in fileBucket)
            {
                try
                {
                    string content = File.ReadAllText(file, Encoding.UTF8);
                    int tokenCount = CountTokens(content);
                    totalTokens += tokenCount;
                    Log($" - {file} ({tokenCount} tokens)");
                }
                catch (Exception ex)
                {
                    Log($" - {file} (Error reading file: {ex.Message})");
                }
            }

            Log($"Total tokens in bucket: {totalTokens}");
        }

        private void ProcessFiles()
        {
            fileCount = 0;
            errors = 0;
            textBox1.Clear();
            Log("Starting operation...");

            if (fileBucket.Count == 0)
            {
                Log("No files in bucket to process.");
                return;
            }

            if (string.IsNullOrEmpty(outputDirectory))
            {
                outputDirectory = ChooseOutputDirectory();
                if (string.IsNullOrEmpty(outputDirectory))
                {
                    Log("No output directory selected. Operation cancelled.");
                    return;
                }
            }

            string finalOutput = Path.Combine(outputDirectory, outputFileName);

            TryDeleteFile(tempOutput, "Existing temporary file found. Deleting...");
            TryDeleteFile(finalOutput, "Existing output file found. Deleting...");

            Log("Concatenating files...");
            foreach (var file in fileBucket)
            {
                Log($"Processing: {file}");
                try
                {
                    File.AppendAllText(tempOutput, File.ReadAllText(file, Encoding.UTF8) + Environment.NewLine);
                    fileCount++;
                }
                catch (Exception ex)
                {
                    Log($"Error processing {file}: {ex.Message}");
                    errors++;
                }
            }

            Log($"Concatenation completed. Total files processed: {fileCount}");
            Log(errors > 0 ? $"There were {errors} errors during concatenation." : "No errors during concatenation.");

            Log($"Minifying concatenated file using {modeComboBox.SelectedItem}...");
            if (MinifyFile(finalOutput))
            {
                Log($"Minification completed successfully. Output saved to: {finalOutput}");
                try
                {
                    string minifiedContent = File.ReadAllText(finalOutput, Encoding.UTF8);
                    int tokenCount = CountTokens(minifiedContent);
                    Log($"Tokens after minification: {tokenCount}");
                }
                catch (Exception ex)
                {
                    Log($"Error reading minified file for token count: {ex.Message}");
                }
            }
            else
            {
                Log("Error occurred during minification.");
                errors++;
            }

            TryDeleteFile(tempOutput, "Cleaning up temporary file...");

            Log("Operation completed.");
            Log(errors > 0 ? $"There were {errors} errors during the entire operation." : "No errors encountered.");
            UpdateOpenOutputButton();
        }

        private bool IsTextFile(string filePath)
        {
            string[] validExtensions = { ".cs", ".txt", ".js", ".css", ".html" };
            return validExtensions.Contains(Path.GetExtension(filePath).ToLower());
        }

        private void TryDeleteFile(string filePath, string message)
        {
            if (File.Exists(filePath))
            {
                Log(message);
                try
                {
                    File.Delete(filePath);
                }
                catch (Exception ex)
                {
                    Log($"Error deleting {filePath}: {ex.Message}");
                    errors++;
                }
            }
        }

        private bool MinifyFile(string outputPath)
        {
            try
            {
                if (modeComboBox.SelectedItem.ToString() == "CSMin (Package)")
                {
                    ProcessStartInfo psi = new ProcessStartInfo
                    {
                        FileName = "csmin.exe",
                        Arguments = "",
                        RedirectStandardInput = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    };

                    using (Process process = new Process { StartInfo = psi })
                    {
                        process.Start();
                        using (StreamWriter sw = process.StandardInput)
                        {
                            sw.Write(File.ReadAllText(tempOutput));
                        }
                        using (StreamReader sr = process.StandardOutput)
                        {
                            File.WriteAllText(outputPath, sr.ReadToEnd(), Encoding.UTF8);
                        }
                        process.WaitForExit();
                        return process.ExitCode == 0;
                    }
                }
                else
                {
                    string content = File.ReadAllText(tempOutput, Encoding.UTF8);
                    string minified = RemoveWhitespace(content);
                    File.WriteAllText(outputPath, minified, Encoding.UTF8);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log($"Minification error: {ex.Message}");
                return false;
            }
        }

        private string RemoveWhitespace(string input)
        {
            // Remove single-line comments
            string result = Regex.Replace(input, @"//.*?$", "", RegexOptions.Multiline);

            // Remove multi-line comments
            result = Regex.Replace(result, @"/\*.*?\*/", "", RegexOptions.Singleline);

            // Remove leading/trailing whitespace, multiple spaces, and unnecessary newlines
            result = Regex.Replace(result, @"\s+", " ");
            result = string.Join(" ", result.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Select(line => line.Trim()));

            // Remove spaces around common delimiters
            result = Regex.Replace(result, @"\s*([{}()[\];,])\s*", "$1");

            return result.Trim();
        }

        private string ChooseOutputDirectory()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select the output directory for the minified file.";
                return fbd.ShowDialog() == DialogResult.OK ? fbd.SelectedPath : string.Empty;
            }
        }

        private void Log(string message)
        {
            textBox1.AppendText(message + Environment.NewLine);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            fileBucket.Clear();
            fileCount = 0;
            errors = 0;
            TryDeleteFile(tempOutput, "Deleting temporary file...");
            TryDeleteFile(Path.Combine(outputDirectory, outputFileName), "Deleting output file...");
            UpdateFileList();
            Log("Reset complete. Ready to add new files.");
            UpdateOpenOutputButton();
        }

        private void AddFilesButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                ofd.Filter = "Text Files (*.cs, *.txt, *.js, *.css, *.html)|*.cs;*.txt;*.js;*.css;*.html|All Files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    AddFilesToBucket(ofd.FileNames);
                }
            }
        }

        private void MinifyButton_Click(object sender, EventArgs e)
        {
            if (fileBucket.Count == 0)
            {
                Log("No files in bucket to minify.");
                return;
            }
            ProcessFiles();
        }

        private void OpenOutputButton_Click(object sender, EventArgs e)
        {
            string outputPath = Path.Combine(outputDirectory, outputFileName);
            if (File.Exists(outputPath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(outputPath) { UseShellExecute = true });
                    Log($"Opened output file: {outputPath}");
                }
                catch (Exception ex)
                {
                    Log($"Error opening output file: {ex.Message}");
                }
            }
            else
            {
                Log("Output file does not exist.");
            }
        }

        private void ChangeDirButton_Click(object sender, EventArgs e)
        {
            string newDir = ChooseOutputDirectory();
            if (!string.IsNullOrEmpty(newDir))
            {
                outputDirectory = newDir;
                Log($"Output directory changed to: {outputDirectory}");
                UpdateFileList();
                UpdateOpenOutputButton();
            }
            else
            {
                Log("No new directory selected.");
            }
        }

        private void UpdateOpenOutputButton()
        {
            openOutputButton.Enabled = File.Exists(Path.Combine(outputDirectory, outputFileName));
        }

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            string outputPath = Path.Combine(outputDirectory, outputFileName);
            if (File.Exists(outputPath))
            {
                try
                {
                    string text = File.ReadAllText(outputPath);
                    Clipboard.SetText(text);
                    Log("Output file copied to clipboard.");
                }
                catch (Exception ex)
                {
                    Log($"Error copying output file to clipboard: {ex.Message}");
                }
            }
            else
            {
                Log("Output file does not exist. Cannot copy to clipboard.");
            }
        }

        private void tokenCountButton_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(outputDirectory, outputFileName);
            if (!File.Exists(filePath))
            {
                filePath = tempOutput;
            }

            if (File.Exists(filePath))
            {
                try
                {
                    string content = File.ReadAllText(filePath, Encoding.UTF8);
                    int tokenCount = CountTokens(content);
                    Log($"Token count: {tokenCount}");
                }
                catch (Exception ex)
                {
                    Log($"Error counting tokens: {ex.Message}");
                }
            }
            else
            {
                Log("No output or temporary file exists to count tokens.");
            }
        }

        private int CountTokens(string content)
        {
            // Remove comments first to avoid counting them
            content = Regex.Replace(content, @"//.*?$", "", RegexOptions.Multiline);
            content = Regex.Replace(content, @"/\*.*?\*/", "", RegexOptions.Singleline);

            // Split by whitespace and common delimiters, count non-empty tokens
            var tokens = Regex.Split(content, @"\s+|[.,;(){}[\]]")
                             .Where(t => !string.IsNullOrWhiteSpace(t))
                             .ToList();
            return tokens.Count;
        }

        private void GithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = "https://github.com/InvalidArgument3/tokenizationifier",
                    UseShellExecute = true
                };
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}