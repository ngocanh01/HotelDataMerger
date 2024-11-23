@echo off
set hotel_ids=%1
set destination_ids=%2

"D:\Source\Repos\HotelDataMerger\HotelDataMerger\bin\Release\net8.0\win-x64\publish\HotelDataMerger.exe" %hotel_ids% %destination_ids%