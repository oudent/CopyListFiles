# CopyListFiles
Simple C# utility for copying a list of files from one directory to another
Written By: Nicholas Brouillard
Date: 2021-07-01

Introduction:
=============
This is my first attempt at C#. I know there are plenty of ways to accomplish the same things with batch files or powershell scripts, but I wanted a simple user interface where I could paste a list of file names from the clipboard (for my purpose, this will generally come from a list in Microsoft Excel), select a from and to folder, and click copy. So, that is what I made.

As this is my first time using C#, and I'm not a professional programmer, this is a very simple program, that was only designed/tested to work in Windows 10, and likely is far from the safest way to copy files. As such, I would advise caution if using this for anything important. The actual file copying is handled by the built in copy function in C#.


Usage:
======
Download and extract a zip file from the bin folder. Run the .exe file.

1) Select the folder to copy from by clicking the FROM button and selecting the folder with dialog that opens, or type it into the text box.
2) Select the folder to copy to by clicking the FROM button and selecting the folder with dialog that opens, or type it into the text box.
3) Paste or type in a list of filenames, with one filename per line
4) If you would like to blindly replace files in the "TO" directory, place a checkmark in the replace files checkbox
5) Click the Copy button
6) If it is taking too long due to having selected too many files, you can click cancel. However, note that the cancel button allows the current file being copied to finish copying (and there is no status indicator to show how far along it is for that file).
