# Operating Systems Lab - Week 03
**Course:** CS211P - Operating System (1)  
**Faculty:** Faculty of Computers and Information - Mansoura University  
**Semester:** Fall 2024-2025  
**Grade:** 2  

---

## Table of Contents
1. [Echo and Cat Commands](#1-echo-and-cat-commands)
2. [Ownership of Linux Files](#2-ownership-of-linux-files)
3. [File Permissions](#3-file-permissions)
4. [Archiving and Compression](#4-archiving-and-compression)
5. [System Information Commands](#5-system-information-commands)
6. [Lab Exercises](#6-lab-exercises)

---

## 1. Echo and Cat Commands

### 1.1 The `echo` Command

The `echo` command is used to display text or strings on the terminal.

**Basic Syntax:**
```bash
echo string
```

**Example:**
```bash
echo "Hello, Operating Systems!"
```
**Output:** `Hello, Operating Systems!`

### 1.2 Redirecting Output to a File

Instead of displaying output on the terminal, you can redirect it to a file using the `>>` operator (append) or `>` operator (overwrite).

**Append to a file:**
```bash
echo "This is a new line" >> fileName.txt
```

**Overwrite a file:**
```bash
echo "This will replace all content" > fileName.txt
```

**Note:** 
- `>` creates a new file or **overwrites** existing content
- `>>` **appends** to the end of an existing file or creates a new one if it doesn't exist

### 1.3 The `cat` Command

The `cat` (concatenate) command is used to read and display file contents.

**Basic Syntax:**
```bash
cat fileName
```

**Example:**
```bash
cat myfile.txt
```

### 1.4 Advanced `cat` Usage

**Display contents with line numbers:**
```bash
cat -n fileName
```

**Example:**
```bash
cat -n script.sh
```
**Output:**
```
     1  #!/bin/bash
     2  echo "Hello World"
     3  # This is a comment
```

**View contents from multiple files:**
```bash
cat fileName1 fileName2
```

**Example:**
```bash
cat file1.txt file2.txt
```

---

## 2. Ownership of Linux Files

In Linux, every file and directory has three types of ownership:

### 2.1 Owner (User - u)
- The **user** who created the file
- Has primary control over the file
- Can modify permissions

### 2.2 Group (g)
- A **group** can contain multiple users
- All users in the group share the same permissions for the file
- Useful for collaborative work

### 2.3 Others (o)
- Represents **everyone else** on the system
- Users who are neither the owner nor in the group
- Typically have the most restricted access

**Example:**
```bash
ls -l myfile.txt
```
**Output:**
```
-rw-r--r-- 1 mahmoud students 1234 Oct 12 10:30 myfile.txt
```
- Owner: `mahmoud`
- Group: `students`
- Others: all other users

---

## 3. File Permissions

Linux uses a permission system to control access to files and directories. There are three types of permissions:

### 3.1 Permission Types

| Permission | Symbol | Numeric Value | For Files | For Directories |
|------------|--------|---------------|-----------|-----------------|
| **Read** | r | 4 | Open and read a file | List directory contents |
| **Write** | w | 2 | Modify file contents | Create, delete, rename files in directory |
| **Execute** | x | 1 | Run as a program | Access directory (cd into it) |
| **No Permission** | - | 0 | No access | No access |

### 3.2 Permission Structure

Permissions are displayed in the following format:
```
-rwxrwxrwx
```

Breaking it down:
```
- rwx rwx rwx
│  │   │   │
│  │   │   └─── Other permissions
│  │   └─────── Group permissions
│  └─────────── Owner permissions
└────────────── File type (- for file, d for directory)
```

**Example:**
```
-rw-r--r--
```
- Owner: read + write (rw-)
- Group: read only (r--)
- Others: read only (r--)

### 3.3 Numeric Permission Calculation

Permissions can be represented as three-digit octal numbers:

| Permission | Calculation | Value |
|------------|-------------|-------|
| rwx | 4 + 2 + 1 | 7 |
| rw- | 4 + 2 + 0 | 6 |
| r-x | 4 + 0 + 1 | 5 |
| r-- | 4 + 0 + 0 | 4 |
| -wx | 0 + 2 + 1 | 3 |
| -w- | 0 + 2 + 0 | 2 |
| --x | 0 + 0 + 1 | 1 |
| --- | 0 + 0 + 0 | 0 |

**Example:** 
- `chmod 755` means:
  - Owner: rwx (7)
  - Group: r-x (5)
  - Others: r-x (5)

### 3.4 Changing Permissions with `chmod`

The `chmod` (change mode) command modifies file permissions.

#### Method 1: Symbolic Method

**Syntax:**
```bash
chmod [who][operation][permission] filename
```

**Who:**
- `u` = user (owner)
- `g` = group
- `o` = others
- `a` = all (user, group, and others)

**Operation:**
- `+` = add permission
- `-` = remove permission
- `=` = set exact permission

**Examples:**
```bash
# Add execute permission for owner
chmod u+x script.sh

# Remove write permission for group
chmod g-w file.txt

# Add read and write for all
chmod a+rw document.txt

# Remove execute for others
chmod o-x program

# Set exact permissions: owner=rw, group=r, others=nothing
chmod u=rw,g=r,o= file.txt
```

#### Method 2: Numeric (Octal) Method

**Syntax:**
```bash
chmod [number] filename
```

**Examples:**
```bash
# Owner: rwx, Group: ---, Others: r--
chmod 704 file.txt

# Owner: rw-, Group: r--, Others: r--
chmod 644 document.txt

# Owner: rwx, Group: r-x, Others: r-x
chmod 755 script.sh

# Owner: rw-, Group: rw-, Others: ---
chmod 660 private.txt
```

**Common Permission Patterns:**
- `644` - Standard file permissions (owner can read/write, others can read)
- `755` - Standard executable/directory permissions
- `700` - Private file/directory (only owner has access)
- `777` - All permissions for everyone (rarely recommended)

---

## 4. Archiving and Compression

### 4.1 Archiving vs. Compression

**Archiving:**
- Collects multiple files and directories into a single file
- **Does not reduce file size**
- Uses `.tar` extension
- Useful for organizing and transferring multiple files

**Compression:**
- Reduces the size of files
- Saves disk space and bandwidth
- Uses extensions like `.gz`, `.zip`
- Useful for storing and transmitting large files

### 4.2 The `tar` Command (Archiving)

`tar` stands for "Tape Archive" and is used to create archive files.

#### Creating an Archive

**Syntax:**
```bash
tar cvf archive_name.tar file1 file2 directory_name
```

**Options:**
- `c` = create a new archive
- `v` = verbose (show progress)
- `f` = specify filename

**Example:**
```bash
tar cvf backup.tar file1.txt file2.txt documents/
```

#### Extracting an Archive

**Syntax:**
```bash
tar xvf archive_name.tar
```

**Options:**
- `x` = extract files from archive
- `v` = verbose
- `f` = specify filename

**Example:**
```bash
tar xvf backup.tar
```

#### Viewing Archive Contents

**Syntax:**
```bash
tar tvf archive_name.tar
```

**Options:**
- `t` = list contents
- `v` = verbose
- `f` = specify filename

**Example:**
```bash
tar tvf backup.tar
```

### 4.3 The `gzip` Command (Compression)

`gzip` compresses a single file and adds `.gz` extension.

#### Compressing a File

**Syntax:**
```bash
gzip filename
```

**Example:**
```bash
gzip largefile.txt
# Creates: largefile.txt.gz (original file is removed)
```

**Note:** By default, `gzip` removes the original file after compression.

#### Decompressing a File

**Syntax:**
```bash
gzip -d filename.gz
# OR
gunzip filename.gz
```

**Example:**
```bash
gzip -d largefile.txt.gz
# Restores: largefile.txt
```

#### Combining tar and gzip

You can create compressed archives using both commands together:

**Method 1: Two-step process**
```bash
tar cvf archive.tar files/
gzip archive.tar
# Creates: archive.tar.gz
```

**Method 2: Single command**
```bash
tar czf archive.tar.gz files/
# c = create, z = compress with gzip, f = filename
```

**Extracting compressed tar archives:**
```bash
tar xzf archive.tar.gz
# x = extract, z = decompress with gzip, f = filename
```

### 4.4 The `zip` Command (Compression)

`zip` compresses files and directories into a `.zip` archive (Windows compatible).

#### Creating a Zip Archive

**Syntax:**
```bash
zip -r archive_name.zip file1 file2 directory_name
```

**Options:**
- `-r` = recursive (include directories)

**Example:**
```bash
zip -r backup.zip file1.txt file2.txt documents/
```

#### Extracting a Zip Archive

**Syntax:**
```bash
unzip archive_name.zip
```

**Example:**
```bash
unzip backup.zip
```

**Extract to specific directory:**
```bash
unzip backup.zip -d /path/to/destination/
```

**View contents without extracting:**
```bash
unzip -l backup.zip
```

---

## 5. System Information Commands

### 5.1 Disk Space Commands

#### `df` - Disk Filesystem Usage

Shows disk space usage for all mounted filesystems.

**Syntax:**
```bash
df -h
```

**Options:**
- `-h` = human-readable format (KB, MB, GB)

**Example Output:**
```
Filesystem      Size  Used Avail Use% Mounted on
/dev/sda1       50G   20G   28G  42% /
/dev/sda2       100G  75G   20G  79% /home
```

#### `du` - Directory Usage

Shows disk space used by directories.

**Syntax:**
```bash
du -hs directory_name
```

**Options:**
- `-h` = human-readable format
- `-s` = summary (total size only)

**Example:**
```bash
du -hs /home/mahmoud/documents/
# Output: 2.3G    /home/mahmoud/documents/
```

### 5.2 Memory Usage

#### `free` - Memory and Swap Usage

Shows memory (RAM) and swap space usage.

**Syntax:**
```bash
free
# OR for human-readable format
free -h
```

**Example Output:**
```
              total        used        free      shared  buff/cache   available
Mem:           7.7G        2.1G        3.2G        256M        2.4G        5.1G
Swap:          2.0G          0B        2.0G
```

### 5.3 System Information Commands

#### Hostname and Network

```bash
# Show computer name
hostname

# Show IP address
hostname -I
```

#### Date and Time

```bash
# Show current date and time
date

# Show calendar for current month
cal

# Show calendar for specific year
cal 2025
```

#### User Information

```bash
# Show current username (Method 1)
echo $USER

# Show current username (Method 2)
whoami

# Show user ID and groups
id
```

**Example Output:**
```bash
$ whoami
mahmoud

$ id
uid=1000(mahmoud) gid=1000(mahmoud) groups=1000(mahmoud),27(sudo),999(docker)
```

### 5.4 Command History

```bash
# Show recently used commands
history

# Save history to a file
history > commands.txt

# Execute a specific command from history
!123    # Runs command number 123

# Execute the last command
!!

# Search command history
history | grep "chmod"
```

### 5.5 Network Testing

#### `ping` - Check Network Connection

Tests connectivity to a server or IP address.

**Syntax:**
```bash
ping server_name
# OR
ping IP_address
```

**Example:**
```bash
ping google.com
ping 8.8.8.8
```

**Stop ping with:** `Ctrl + C`

**Limit number of pings:**
```bash
ping -c 5 google.com
# Sends only 5 ping packets
```

### 5.6 Exit Terminal

```bash
exit
# OR press Ctrl + D
```

---

## 6. Lab Exercises

### Exercise 1: Echo and Cat Commands

1. Create a file named `greeting.txt` with the text "Hello from FCIS" using `echo`
2. Display the contents of `greeting.txt` using `cat`
3. Append "Mansoura University" to the file
4. Display the file with line numbers
5. Create another file `info.txt` with your name and student ID
6. Display both files together using a single `cat` command

**Solution:**
```bash
echo "Hello from FCIS" > greeting.txt
cat greeting.txt
echo "Mansoura University" >> greeting.txt
cat -n greeting.txt
echo "Name: Mahmoud Abas" > info.txt
echo "Student ID: 12345" >> info.txt
cat greeting.txt info.txt
```

### Exercise 2: File Permissions

1. Create a file named `script.sh` with some text
2. Check its current permissions using `ls -l`
3. Give the owner execute permission using symbolic method
4. Remove write permission from group using symbolic method
5. Set permissions to 755 using numeric method
6. Create a directory and set its permissions to 700

**Solution:**
```bash
echo "#!/bin/bash" > script.sh
echo "echo 'Test script'" >> script.sh
ls -l script.sh
chmod u+x script.sh
chmod g-w script.sh
chmod 755 script.sh
mkdir mydir
chmod 700 mydir
ls -ld mydir
```

### Exercise 3: Archiving and Compression

1. Create three text files with different content
2. Create a tar archive containing all three files
3. List the contents of the archive
4. Extract the archive to verify
5. Compress one of the files using `gzip`
6. Create a zip archive of all files
7. Check the size difference between original and compressed files

**Solution:**
```bash
echo "File 1 content" > file1.txt
echo "File 2 content" > file2.txt
echo "File 3 content" > file3.txt

tar cvf myarchive.tar file1.txt file2.txt file3.txt
tar tvf myarchive.tar
tar xvf myarchive.tar

gzip file1.txt
ls -lh

zip myfiles.zip file2.txt file3.txt file1.txt.gz
ls -lh
```

### Exercise 4: System Information

1. Display your computer's hostname
2. Show your IP address
3. Display current date and time
4. Show this month's calendar
5. Check disk space usage in human-readable format
6. Check the size of your home directory
7. Display memory usage
8. Show your username using three different methods
9. Ping google.com 5 times

**Solution:**
```bash
hostname
hostname -I
date
cal
df -h
du -hs ~
free -h
echo $USER
whoami
id
ping -c 5 google.com
```

### Exercise 5: Comprehensive Challenge

Create a script that:
1. Creates a directory named "lab3_project"
2. Inside it, creates three subdirectories: "docs", "scripts", "data"
3. Creates sample files in each directory
4. Sets appropriate permissions (755 for directories, 644 for files)
5. Creates a compressed tar archive of the entire project
6. Shows the size comparison between the directory and the archive

**Solution:**
```bash
# Create directory structure
mkdir -p lab3_project/{docs,scripts,data}

# Create sample files
echo "Documentation file" > lab3_project/docs/readme.txt
echo "#!/bin/bash" > lab3_project/scripts/run.sh
echo "echo 'Running script'" >> lab3_project/scripts/run.sh
echo "Sample data: 1,2,3,4,5" > lab3_project/data/data.csv

# Set permissions
chmod 755 lab3_project lab3_project/*
chmod 644 lab3_project/docs/* lab3_project/data/*
chmod 755 lab3_project/scripts/*

# Create compressed archive
tar czf lab3_project.tar.gz lab3_project/

# Show size comparison
echo "Directory size:"
du -hs lab3_project/
echo "Archive size:"
ls -lh lab3_project.tar.gz
```

---

## Summary

In this lab, you learned:

✅ **Echo and Cat Commands:** Display text and read file contents  
✅ **File Ownership:** Understanding user, group, and others  
✅ **File Permissions:** Reading, writing, and executing files using symbolic and numeric methods  
✅ **Archiving:** Using `tar` to bundle files together  
✅ **Compression:** Reducing file sizes with `gzip` and `zip`  
✅ **System Commands:** Checking disk space, memory, network connectivity, and user information

---

## Additional Resources

- Linux Manual Pages: `man command_name` (e.g., `man chmod`)
- Linux Command Help: `command_name --help` (e.g., `chmod --help`)
- Online Resources:
  - [Linux Journey](https://linuxjourney.com/)
  - [Ubuntu Documentation](https://help.ubuntu.com/)
  - [GNU Core Utilities](https://www.gnu.org/software/coreutils/manual/)

---

## Tips for Success

1. **Practice regularly** - Linux commands become easier with repetition
2. **Use tab completion** - Press Tab to auto-complete filenames and commands
3. **Read error messages** - They usually tell you what went wrong
4. **Use `man` pages** - They contain detailed information about commands
5. **Be careful with permissions** - Wrong permissions can make files inaccessible
6. **Backup before compression** - Always keep a copy of important files

---

**End of Lab 03**

