   Visit www.radioactivepages.com for the most recent information.
   ---------------------------------------------------------------

AsfBin is a command line utility for cutting out fragments, joining, editing
and repairing ASF files. AsfBin can be applied for any ASF file, that is, not
only those with ASF extension but also those with WMV and WMA extensions. 
The whole operation is performed without any recompression. Thus the video 
quality is not degraded and the resulting file remains as unchanges as 
possible.
In the previous versions of the result of an operation was always one media 
file. But since version 1.5 a -sep option was introduced to allow a user to 
save each selected range to a separate file. Other unique feature is
the ability to recreate key frames basing on progressive ones, thus 
allowing to cut the video at any desired time position. 
Because AsfBin do not rely on ASF file index, it can skip damaged area 
and repair the data stream starting from first good samples.

AsfBinGUI is window counterpart of the AsfBin command line utility,
providing the same level of functionality and clear user interface.

AsfBin and AsfBinGUI is FREE is for non-commercial use.

Copyright© 2001-2012 by RadioActive.

Limited Warranty:
This software is provided "as is" without express or implied warranty. 
Use it at your own risk! Whilst I have made every effort to remove any undesirable bugs, 
I cannot be held responsible if it causes any damage, loss of time or data. 
It would be highly recommended to backup your data before using this application. 
It would also be very wise to work with a copy of the file you are about to process.

All mentioned Trademarks and Copyrights belong to their respective owners.



Requirements:
============================================================================
- Windows operating system (98, Me, Win2000, XP, Windows Server 2003, 
  Windows Server 2008, Vista or Windows 7)


Installation:
============================================================================
Unzipp the executable files and copy them to a desired location.
The best place to copy an asfbin.exe file is the WINDOWS directory (e.g. C:\WINDOWS). 
By doing so you will have an access to this tool from any directory on 
any hard-drive. 


Usage:
============================================================================
asfbin [INPUT MEDIA FILES] -o <out_file> [SWITCHES]
 [INPUT MEDIA FILES] can be specified by:
   -i <in_file>       - input windows media file, can be repeated many times,
   -l <in_file_list>  - file containing list of files to join.
 [SWITCHES] are as follow:
   -sep               - write each segment to a separate file.
                        Output file name will be treated like a name template
                        where all occurences of {000} or {  } are replaced by 
                        the segment number. If {0} is not present, a number will 
                        be inserted right before the file name extension. 
                        E.g. "MyName0001.asf". "{000}" is replaced by e.g. "001",
                        and "{   }" is replaced by "   1".
   -s <segments_list> - file containing list of segments to extract,
   -a <attrib_list> (or -attr)
                      - file containing list of attributes to set.
   -m <marker_list> (or -markers)
                      - file containing list of markers to set.
   -k <script_list> (or -scripts)
                      - file containing list of scripts to set.
   -cfg (or -config)
                      - force codecs configuration check.
                        By default AsfBin performs it only once on a given
                        system. 
   -start <time>      - start copying from specified time,
   -dur <time>        - copy segment of specified time,
                        these two switches can be repeated many times,
                        each pair defining a new segment to extract,
   -stop <time> (or -end)
                      - stop copying at specified time,
   -invert (or -invertsel, -invsel)
                      - invert selection. Specified segments will be removed
   -repeat <n>        - repeat the entire resulting file <n> times.
   -istart            - don't wait for key frame. Files are joined without any
                        advanced fitting. Can be used for files previously cut.
                        By default copying starts after finding a key frame.
   -cvb               - always copy very beginning of an input file
                        discarding even finding key frame
                        when joining too or more files,
   -brkaud (or -breakaudio or -ba)
                      - audio streams junctions will be marked as gap.
                        Since version 1.6 this option is turned off by default.
                        If still some problems with audio are experinced when
                        playing with MS WMPlayer (any version) then please turn
                        this option on. Other players like Media Player Classis
                        are free from this bug.
   -brkvid (or -breakvideo or -bv)
                      - video streams junctions will be marked as gap.
                        This option may be usefull when joining two files
                        encoded by slightly different versions of codec what
                        may cause artefacts appear on segment junctions.
   -ebkf (or -endbeforekf)
                      - streams will end before nearest past key frame,
   -u (or -unique or -uniq)
                      - makes resulting files unique by changing original
                        ASF file identificators into unique ones,
   -act (or -aft)     - adjust creation time of the file to the time of
                        creation of the original file plus start time.
   -nots              - leaves sample times and packet times unchanged.
   -rkf (or -recreatekf)
                      - recreate key frames when needed. This mode does not 
                        guarantee correct results. While it is highly likely 
                        that WMV3, MP42 and MP43 video formats will be correctly 
                        handled, all other formats will not be probably recognized,
   -dmo               - (*NEW*) force using DMO when recompressing video samples,
   -vcm               - (*NEW*) force using VCM when recompressing video samples,
   -noidx (or -noindex)
                      - don't index output file,
   -forceindex        - force writting advanced index,
   -sionly            - simple index only,
   -nomarkers         - don't copy markers,
   -noscripts         - don't copy script command,
   -nostr <numbers> (or -nostream, -excludestr, -exclstr, -removestr)
       	              - don't copy selected streams.
                        <numbers> are stream numbers separated by space or
                        comma. This switch can be used many times.
   -q                 - quiet mode - only few information are presented,
   -v                 - verbose mode - turned on by default,
   -details           - stronger verbose mode - shows many details about
                        copying process, among other things key frames,
   -debug             - strongest verbose mode - debug mode,
   -y                 - overwrite without asking,
   -bw <milliseconds> - forces setting of the initial play delay. This value
                        has direct impact on the internal bucket size.
                        Selecting too small value may cause sample losing.
   -ps <bytes>        - forces size of data packets.
   -optps             - optimized packet size to minimize data padding.
   -rmgaps            - big time gaps are removed. This option is not yet active!
   -adelay <time>     - audio delay. Can be negative value,
   -sdelay <number> <time> - stream delay. Can be negative value,
   -info              - just show information on input sources.
   -infokf            - just show information on input sources and locations
                        of key frames in selected time range.
   -infoidx           - show detailed information on indices appended to a 
                        processed file. Add -details switch to get additional
                        information on any eventual errors.
   -infohdr           - show detailed information on input ASF file header.
   -h                 - show this help screen.
 <time> in general is given in seconds, but it accepts
 following formats as well:
   1:59:45.35 = 1 h, 59 min, 45s, 35 hundredths, 3:30 = 3 min, 30 sec.,
   1023.101 = 1023 sec. and 101 thousandths, etc.
 <in_file_list> format: - each line contains next file to read/join.
 <segments_list> format: - each line contains one segment description:
    <start_time><separators><duration> e.g.: 14:45, 3:00
 <attrib_list> format: - each line consists of: <attribute_name>=<value>
    The format is similar to the format of *.INI files.
    Following attributes are available to set:
    Title, Author, Description, Rating, Copyright.
 <marker_list> format: - each line consists of: <time> <marker_name>
 <script_list> format: - each line consists of:
    <time> <command_type> <command_string>, where command type is "URL"
    or "FILENAME". Custom types are also allowed.
 (*) - those options does not guarantee correct results. While it is
       highly likely that WMV3, WVC1, WMVA, MP42 and MP43 video formats
       will be correctly handled, all other formats may not be
       recognized.
All input list files can be in UTF-8 format. The following escape characters 
may be used:
'\ ' - space (like on the value beginning - if not escaped all 
       whitespaces are trimmed from values),
'\t' - tab,
'\n' - new line character,
'\r' - carriage return character,
'\\' - backslash,
	   
	   
Examples of usage:
============================================================================
1. To join two ASF files into one big please type:
   asfbin -i first.asf -i second.asf -o big.asf 
   
2. To cut out a fragment from a bigger ASF file please type:
   asfbin -i big.asf -o part.asf -start 10:03.045 -duration 30.01
   
3. To cut some fragment from a file that begins in the middle and
   lasts to the end of file simply give only -start parameter
   without duration.
   asfbin -i big.asf -o endpart.asf -start 5:45
   
4. To extract two segments from one bigger ASF file and put in a one
   file please type:
   asfbin -i big.asf -o smaller.asf -start 1:15 -dur 4:00 -start 10:15 120 
   
5. To join many ASF files into one big You can also use input file list:
   asfbin -l files.lst -o bigone.asf
   
6. To work on the list of ASF files like on the one big file and to cut
   some fragments from it, please specify:
   asfbin -l files.lst -o parts.asf -s segments.lst 
   
7. To delay audio stream by 350ms type:
   asfbin -i input.asf -o output.asf -adelay 0.35

8. To advance stream number 4 by 250ms type:
   asfbin -i input.asf -o output.asf -sdelay 4 -0.25

9. To join two ASF files into one big please type knowing that the second file
   may contain progressive frames that are a continuation of the first file, type:
   (E.g. your encoder software may save streams in segmented file, each of size 50MB.
   In that case using -cvb may be helpful.)
   asfbin -i first.asf -i second.asf -o big.asf -cvb

10. To remove low bitrate audio and video streams assuming that those are respectively 
   streams number 1 and 3, invoke command:
   asfbin -i input.asf -o output.asf -nostr 1,3
   
11. To extract 10 time ranges from the long input file and save them
   under names: short01.asf, short02.asf and so on, assuming that
   time ranges are kept in timeranges.txt file, invoke the command below.
   We also want each file to be unique.
   asfbin -i long.asf -l timeranges.txt -sep -o short{00}.asf -unique
  
12. To print out the information on precise location of all key frames
   in the input file please run:
   asfbin -i input.asf -infokf 

13. To print out the information on index entries in the input file 
   please run:
   asfbin -i input.asf -infoidx -details > some.log
   
14. If you want to divide file into several segments, send it via e-mail 
   or in any other way and then join it together with no losses follow
   the instructions:
   
   asfbin -i large.wmv -o partA.wmv -y -start 0 -dur 10 -ebkf
   asfbin -i large.wmv -o partB.wmv -y -start 10 -dur 10 -ebkf
   asfbin -i large.wmv -o partC.wmv -y -start 20 -dur 10 -ebkf
   asfbin -i large.wmv -o partD.wmv -y -start 30 -dur 10 -ebkf
   
   and join it together again:
   
	 asfbin -i partA.wmv -i partB.wmv -i partC.wmv -i partD.wmv -o large.wmv -y -istart

Known bugs & Bugs reporting
============================================================================
Visit www.radioactivepages.com for recent information.

More information on AsfBin can be found on my homepage
  http://www.radioactivepages.com
