# Playlist-Sync

**Platform: Windows** (can also be built for Linux)

## Warning

This program will sort all playlists alphabetically. It won't be able to restore your order!

## Description

##### Keep playlists and files in sync

The "music library" window allows you to rename files and folders without losing the playlists: When you rename anything in the program it will both change the name of the file(s)/folders and adopt the new filepaths in the playlists. Additionally it detects if the folder name maches the artist or album tag of the music files. Whenever they match changing the folder name will also change the tag of the files.

##### Synchronize the playlists with an android device

The "multiple playlist conversion" allows you to configure one-click conversions between different formats (.m3u, .m3u8, .playlistsync, .xml).

##### Clean .m3u files

The option "Clean m3u files" allows you to remove all metadata (everything starting with a '#'; e.g. "#EXTINF:...") from the playlist. Optionally it also replaces all relative paths with absolute paths. Sometimes it's necessary to use this if a conversion fails.

## Download

The binaries are available under [Releases](https://github.com/Sogolumbo/Playlist-Sync/releases).

Make sure that you have the [.NET Framework Runtime 4.6.1 or newer](https://www.microsoft.com/net/download/windows) installed (most likely it's already there).

## Recommended Setup / Software

This setup is what I personally use. I do most organization work on the pc and the playlist allocation on my phone.

Use Playlist-Sync to change file names and folder names or move files and folders in your music library.

Use git version control on the playlist files ("User\Music\Playlists"). Recommended GUI: [ungit](https://github.com/FredrikNoren/ungit/releases).

Use [freac](https://www.freac.org/)to copy your cds (works, whenever Windows Media Player crashes).

Use [kid3](https://kid3.kde.org/) to tag and name new files correctly. (This can also partially be done inside Playlist-Sync)

#### Android Playlist sync

This setup only allows you to change the playlists on one device at once. You have to copy the changes to before making changes on the next device. The git version control will help whenever you forgot to copy changes before changing the device.

###### pc -> phone

Use Playlist-Sync and  to convert the playlists into Smart-backup .xml files.

Use [Free file sync](https://freefilesync.org/) or other synchronization software to setup a configuration which will copy the .xml files and music files onto your phone.

Use [my version](https://github.com/Sogolumbo/Slight-backup/releases) of [Smart-backup](https://github.com/handschuh/Slight-backup) to import the .xml files into the android playlist database.

Use any app of your choice or [my version](https://github.com/Sogolumbo/Phonograph/releases) of [Phonograph](https://github.com/kabouzeid/Phonograph) to play/edit the playlists on the phone.

###### phone -> pc

*Check on git that you didn't make any changes on the pc. If you did, there's no recipe on how to fix this. Ine the best case you can just move on as if nothing happened, in the worst case you might have to fix some playlist files manualy (using a text editor).*

Use any version of Smart-backup to export the .xml files onto your phone.

Use Free file sync to copy the .xml files from your phone to your pc.

Use Playlist-Sync to convert the newest .xml file into m3u playlists and save them into your folder.

*Check all the changes you made on git. If everything looks fine you can commit now. If you had changes made on your pc at the beginning you might have to repair some stuff now. Open the "music library" and make sure there are no "missing items" (red background).*

## Configuration

The default settings are stored in `PlaylistSyncGUI.exe.config`.

Your user settings are stored at `%Appdata%\..\Local\PlaylistSyncGUI` in the file `user.config` (this is where the button in the main menu takes you).

To use the external programs (notepad++, kid3) you might have to change the file paths in the config file:

Copy the following lines from the default settings into your user settings. Then replace the file paths with the file paths of your system.



```xml
    <setting name="kid3_FilePath" serializeAs="String">
        <value>C:\Portable Programs\kid3-3.7.0-win32\kid3.exe</value>
    </setting>
    <setting name="notepadPlusPlus_FilePath" serializeAs="String">
        <value>C:\Program Files (x86)\Notepad++\notepad++.exe</value>
    </setting>
```

It happened to me multiple times that I lost my settings. If this happens to you you can most likely restore the old settings by finding the old `user.config` file and copying the contents into the new file.

## Screenshot
![Playlist-Sync_v1 1 2](https://user-images.githubusercontent.com/33571916/101524396-27be8700-398a-11eb-9115-8c6a907b014f.png)
