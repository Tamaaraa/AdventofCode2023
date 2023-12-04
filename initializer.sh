#!/bin/bash

# Loop through folders day_1 to day_24
python ./folder_maker.py

for i in {01..24}
do
    folder_name="day_$i"
    
    # Check if the folder exists before running the command
    if [ -d "$folder_name" ]; then
        echo "Entering $folder_name"
        cd "$folder_name" || exit 1  # Change directory, exit if failed
        dotnet new console
        cd ..  # Move back to the parent directory
        echo "Command executed in $folder_name"
    else
        echo "Folder $folder_name does not exist."
    fi
done
