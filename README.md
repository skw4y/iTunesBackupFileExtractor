iTunes Backup File Extractor
===========
Simple quick & dirty app that extract all the media files contained in your iTunes non-encrypted backup.

Windows only for the moment.

Description
---- 
iTunes stores a copy of all your iDevice files in a backup folder.
Those files can't be view directly because iTunes encrypts the filenames using SHA-1.

The purpose of this application is to retrieve the right extension by reading the Magic Number of each backup files, rename the files and copy them in the output folder.


Usage
=====
Compile application using Visual Studio.

Just run the app, select your iTunes backup folder, your output folder and click on "Go!" to start the extraction.

iTunes backup folder example: 
- Windows 7 : "C:\Users\[USERNAME]\AppData\Roaming\Apple Computer\MobileSync\Backup\[YOUR_BACKUP_FOLDER\]"

- Windows XP : "C:\Documents and Settings\[USERNAME]\Application Data\Apple Computer\MobileSync\Backup\[YOUR_BACKUP_FOLDER\]"

  
Extracted files 
=====
The app will extract the following files:

- Images
 - JPG
 - BMP
 - GIF
 - TIF
 - PNG
	
- Videos
 - MOV
 - MP4
 - AVI
 - FLV
	
- Audio files
 - WMV
 - MP3
 - FLAC
 - M4A
	
- Compressed files
 - ZIP
 - RAR
 - GZ
	
- Database files
 - SQLITE
	
- Other files
 - PDF
	
  
Known Limitations
=================
- Does not work with encrypted backup.

- Does not rename your backup files. The filename result will be a sha1 string but with the right extension.

- This is Captain Obvious and I want to say that this app will not extract anything if you backup your iDevice with iCloud! It only works with old-school computer backup.

	 
License
=======
MIT License.  Copyright 2014 Skw4y.