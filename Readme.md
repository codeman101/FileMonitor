
This is a project I worked on for a friend consisting of two programs.
The two program are called FileLogger and FileMonitor. 

# FileLogger 

This is a console program that logs the given file or directory in FileList.txt which is created in C:\Users\Public\Documeents

# FileMonitor

This program is a windows service that monitors the file list by checking it every few hours to see if a file or directory is old enough to be deleted. 
If the given file is old enough it goes to the given file path and deletes the file or directory.

# FileMonitor install instructions

run command prompt as admin go to the where the executable of the service is and type the following "C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe" FileMonitor.exe
