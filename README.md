iTunes Backup File Extractor
===========
Simple app that extract all the media files (Images, Videos, Music...) contained in your iTunes backup.


Description
---- 
iTunes stores a copy of all your iDevice files in a backup folder.
Those files can't be view directly because iTunes encrypts the filenames using SHA-1.

The purpose of this application is to retrieve the right extension, rename the files and copy them in the output folder.


Usage
=====
Compile application using Visual Studio.

Just run the app, select your iTunes backup folder, your output folder, select the filetypes you want to extract and click on "Go!" to start the extraction.

iTunes backup folder example: 
- Windows 7 : "C:\Users\USERNAME\AppData\Roaming\Apple Computer\MobileSync\Backup\YOUR_BACKUP_FOLDER"

- Windows XP : "C:\Documents and Settings\USERNAME\Application Data\Apple Computer\MobileSync\Backup\YOUR_BACKUP_FOLDER"

  
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
 - 3GP
 - AVI
 - FLV
	
- Audio files
 - WMV
 - MP3
 - FLAC
 - M4A
 - M4P
 - AAC
 - WAV
 - AAX
 - AA
	
- Documents
 - DOC
 - DOCX
 - PPT
 - PPTX
 - XLS
 - XLSX
 - PDF
 - TXT
	
- Database files
 - SQLITE
	
  
Known Limitations
=================
- Does not work with encrypted backup.

- This is Captain Obvious and I want to say that this app will not extract anything if you backup your iDevice with iCloud! It only works with old-school computer backup.

	 
Contact
=======
You can contact me at: string.Format("{0}#{1}","contact","skway.fr").Replace("#","@");

Donations are welcome:
- BTC: 174Eud8voesGp3YcpzjZJGjcjYAr2V42fH

Written by Skw4y in 2014. Released under the terms of the MIT License.  
