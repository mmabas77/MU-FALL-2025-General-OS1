# Operating System (1) - Week 02 Lab

**Course:** CS211P - Operating System (1)  
**Institution:** Mansoura University - Faculty of Computers and Information  
**Department:** Computer Science  
**Grade Level:** 2  

---

## Lab Overview

This lab introduces students to the Linux Operating System, specifically Ubuntu, and covers fundamental terminal commands for file and directory management. The focus is on command-line interface (CLI) operations, which are essential for system administration and development work.

---

## Topics Covered

### 1. Terminal Basics
- Understanding the terminal interface
- The tilde (`~`) symbol as an abbreviation for the user's home directory
- Command syntax: `command [options] [arguments]`
- Separating multiple commands with semicolon (`;`)

### 2. Getting Help
- **man command**: Access manual pages for detailed command documentation
  - `man [command_name]`
  - Options: `-k` (search by keyword), `-f` (search exact name)
- **--help option**: Quick usage information
  - `command_name --help`

### 3. Essential Linux Commands

#### Directory Navigation & Information
- **pwd** - Print Working Directory
  - Shows current directory location
  
- **cd** - Change Directory
  - `cd /path/to/directory` - Move to specific path
  - `cd ..` - Move up one directory level
  - `cd ~` or `cd` - Move to home directory
  - `cd -` - Return to previous directory

#### Directory Listing
- **ls** - List Directory Contents
  - Basic usage: `ls [directory_name]`
  - Common options:
    - `-a` - Show all files (including hidden)
    - `-l` - Long format with detailed information
    - `-lh` - Long format with human-readable file sizes
    - `-ld` - Directory information only (not contents)
    - `-d` - Information about directory/file itself
    - `-F` - Append indicator characters to special files

#### File & Directory Creation
- **touch** - Create New File
  - `touch file1`
  
- **mkdir** - Make Directory
  - `mkdir folder_name`
  - `-p` option: Create parent directories as needed
    - `mkdir -p new_folder/folder1`

#### File & Directory Operations
- **cp** - Copy Files/Directories
  - `cp [options] source target`
  - `-i` - Interactive mode (prevent overwriting)
  - `-r` - Recursive copy (for directories with contents)
  
- **mv** - Move or Rename Files/Directories
  - `mv [options] source target`
  - `-i` - Interactive mode (prevent overwriting)

#### File & Directory Removal
- **rm** - Remove Files
  - `rm file_name`
  - `-r` option: Remove directory and contents
  
- **rmdir** - Remove Empty Directory
  - `rmdir directory_name` (only works if directory is empty)
  - Use `rm -r directory_name` for non-empty directories

---

## Command Syntax Structure

All Linux commands follow this general syntax:
```
command [options] [arguments]
```

- **command**: The action to perform
- **options**: Modifiers that change command behavior (usually prefixed with `-` or `--`)
- **arguments**: Files, directories, or other information the command needs
- Items are separated by spaces

---

## Learning Objectives

By completing this lab, students will be able to:
1. Navigate the Linux file system using terminal commands
2. List and view directory contents with various formatting options
3. Create, copy, move, and delete files and directories
4. Use help resources (man pages and --help) to learn about commands
5. Understand basic command syntax and structure
6. Work efficiently with the Linux command-line interface

---

## Prerequisites

- Ubuntu Linux installed (or any Linux distribution)
- Access to the terminal/command line
- Basic understanding of file system hierarchy

---

## Getting Started

To open the terminal in Ubuntu:
1. Click on the search option
2. Enter "command" or "terminal" in the search box
3. Double-click the Terminal option from search results

---

## Practice Tips

- Use the `man` command to explore more options for each command
- Practice navigating between directories using relative and absolute paths
- Always use the `-i` option when copying or moving files to prevent accidental overwrites
- Use `Tab` key for auto-completion of file and directory names
- Use arrow keys to navigate through command history

---

## Additional Resources

- Ubuntu Official Documentation: https://help.ubuntu.com
- Linux Command Line Basics: Use `man intro` for introduction
- Practice commands in a safe environment before using them on important files

---

## Notes

- The `~` symbol is shorthand for your home directory
- Hidden files in Linux start with a dot (`.`)
- Be careful with `rm` command - deleted files cannot be easily recovered
- Use `pwd` frequently to know your current location in the file system

---

**Last Updated:** Week 02, First Semester 2024-2025
