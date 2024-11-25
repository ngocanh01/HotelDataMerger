@echo off
set hotel_ids=%1
set destination_ids=%2

REM Get the directory of the current batch file
set script_dir=%~dp0
set exe_path="%script_dir%bin\Release\net8.0\win-x64\publish\HotelDataMerger.exe"

REM Run the executable with the provided arguments
%exe_path% %hotel_ids% %destination_ids%

REM Pause to keep the console window open in case of errors
pause