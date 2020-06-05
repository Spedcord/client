@echo off

bitsadmin /transfer mydownloadjob /download /priority FOREGROUND "https://github.com/Spedcord/ets2-sdk-plugin/releases/download/final/64_ets2-telemetry.dll" ".\file.dll"

pause