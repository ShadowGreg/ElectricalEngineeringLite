#!/bin/bash

# Путь к папке, в которой нужно найти файлы
folder_path="./"

# Расширение файлов, которые нужно найти
file_extension=".cs"

# Файл, в который будут сохраняться имена найденных файлов
output_file="./utput_file.txt"

# Функция для поиска файлов с заданным расширением в папке и ее подпапках
find_files() {
    find "$1" -type f -name "*$2"
}

# Поиск файлов с заданным расширением в папке и ее подпапках
files=$(find_files "$folder_path" "$file_extension")

# Сохранение имен найденных файлов в файл
echo "$files" > "$output_file"

echo "Имена найденных файлов сохранены в файле $output_file"