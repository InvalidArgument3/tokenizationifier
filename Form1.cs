using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tokenizationifier
{
    public partial class Form1 : Form
    {
        private readonly string tempOutput = "temp_concatenated.txt";
        private readonly string outputFileName = "minified_output.txt";
        private string outputDirectory; // Set initially or via Change Directory
        private int fileCount = 0;
        private int errors = 0;
        private readonly List<string> fileBucket = new List<string>();

        public Form1()
        {
            InitializeComponent();
            SetupDragDrop();
            outputDirectory = Application.StartupPath; // Default to app directory
            UpdateFileList();
            UpdateOpenOutputButton();
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
            }
            else
            {
                Log($"Files in bucket ({fileBucket.Count}):");
                foreach (var file in fileBucket)
                {
                    Log($" - {file}");
                }
            }
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

            // Ensure output directory is set
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

            // Delete existing temp/output files
            TryDeleteFile(tempOutput, "Existing temporary file found. Deleting...");
            TryDeleteFile(finalOutput, "Existing output file found. Deleting...");

            // Concatenate files
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

            // Minify
            Log("Minifying concatenated file...");
            if (MinifyFile(finalOutput))
            {
                Log($"Minification completed successfully. Output saved to: {finalOutput}");
            }
            else
            {
                Log("Error occurred during minification.");
                errors++;
            }

            // Clean up
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
            catch (Exception ex)
            {
                Log($"Minification error: {ex.Message}");
                return false;
            }
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
            //copy the text in the output file to clipboard, if it exists
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

        private void GithubLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Use ProcessStartInfo to open the URL in the default browser
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/InvalidArgument3/tokenizationifier",
                    UseShellExecute = true // Ensures the URL opens in the default browser
                };
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                // Handle any errors (e.g., no default browser set)
                MessageBox.Show($"Error opening link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}