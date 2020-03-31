# MoveCute
The Cute File Mover

MoveCute is a simple application that is designed to move files automatically between directories based on dates encoded in the file names.
For example, if directory A contains files `2020-08-24_source.txt`, `2020-08-25_source.txt`, and `2020-08-26_source.txt` and directory B contains the file `sink.txt`, MoveCute can be configured to automatically move `2020-08-24_source.txt` to `sink.txt` on Aug 24th, `2020-08-25_source.txt` to `sink.txt` the next day, and so on.

This is the result of the "Media Downloader" Lightsys Spring Break project.
MoveCute does not actually download files though, so that is a bit confusing.

It's for Windows, because a Linux user would just write a script.

## Tutorial
The tutorial as well as the executable are available in the releases.

## Use cases
This is designed to be used by Radio DJs to automatically move files from a location like a mapped network drive or a synced Dropbox folder into their working directory automatically.
As mentioned before, this does not actually download anything, and instead relies on other applications to keep files synced to the user's computer.
It is designed to be generic, however, and could be part of any number of workflows.

### TODO:
* FileSync Priority Option
	* FileSyncs could have the capability to specify which file it will select when it matches multiple files. (earliest modified, closest to today, most recent, most recently updated)
 * FileSync Stores and Displays error
	* Error should be added at the FileSync level so users can quickly figure out what went wrong
* Support '/' syntax (unix style)
	* Treat all forward slashes '/' the same way as backslashes '\'
* Use File System Watchers to trigger Auto Sync
	* Add an option to trigger Syncing when a change is detected in the directory that the Source Macro is pointing to
