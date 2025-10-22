# Code Counter WPF Application

## Overview
This is a simple WPF application built with .NET that allows users to select a folder and automatically counts the number of code files and the total lines of code within that folder and its subfolders.

## Features
- Folder selection via a browse dialog.
- Counts files with common code extensions (e.g., .cs, .cpp, .py, .js, etc.).
- Calculates total lines of code by summing lines in all counted files.
- Displays results in the UI.

## Requirements
- .NET 6.0 or later (WPF support).
- Windows operating system (since WPF is Windows-specific).

## Installation
1. Clone or download the repository.
2. Open the solution in Visual Studio.
3. Build and run the project.

## Usage
1. Launch the application.
2. Click the "Browse" button to select a folder.
3. The app will display:
   - Number of code files found.
   - Total lines of code.

## Configuration
You can modify the list of file extensions considered as code files in the source code (e.g., in MainWindow.xaml.cs).

## Limitations
- Does not count blank lines or comments separately.
- Recursive search includes all subfolders.

## Contributing
Feel free to fork and submit pull requests.

## License
MIT License.