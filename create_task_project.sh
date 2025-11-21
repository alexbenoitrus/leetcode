#!/bin/bash

# Определяем ОС для правильного использования sed
if [[ "$OSTYPE" == "darwin"* ]]; then
    # macOS
    SED_INPLACE="sed -i ''"
else
    # Linux и другие
    SED_INPLACE="sed -i"
fi

# Функция для капитализации каждого слова
capitalize_each_word() {
    echo "$1" | awk '{for(i=1;i<=NF;i++) $i=toupper(substr($i,1,1)) substr($i,2)}1'
}

# Проверка наличия аргумента
if [ $# -eq 0 ]; then
    echo "Usage: $0 \"XXXX. Task name\""
    echo "Example: $0 \"29. Copy All Elements\""
    exit 1
fi

input="$1"

# Проверяем существование исходной папки и solution файла
if [ ! -d "_0000. Example" ]; then
    echo "Error: Source directory '_0000. Example' not found!"
    exit 1
fi

if [ ! -f "LeetCode.sln" ]; then
    echo "Error: Solution file 'LeetCode.sln' not found!"
    exit 1
fi

# Разбор входной строки
if [[ ! "$input" =~ ^([0-9]{1,4})\.\ (.+)$ ]]; then
    echo "Error: Invalid input format. Expected: 'XXXX. Task name'"
    exit 1
fi

number="${BASH_REMATCH[1]}"
task_name="${BASH_REMATCH[2]}"

# Форматирование числа с ведущими нулями
formatted_number=$(printf "%04d" "$number")

# Создание имени папки (с пробелами)
folder_name="_${formatted_number}. ${task_name}"

# Создание имени для замены в файлах (без пробелов и с капитализацией)
capitalized_task_name=$(capitalize_each_word "$task_name")
namespace_name="_${formatted_number}.${capitalized_task_name// /}"

echo "Creating task: $folder_name"
echo "Namespace: $namespace_name"

# 1. Копируем папку
echo "Copying directory..."
cp -r "_0000. Example" "$folder_name"

# 2. Переименовываем .csproj файл
echo "Renaming project file..."
old_csproj="$folder_name/_0000. Example.csproj"
new_csproj="$folder_name/$folder_name.csproj"

if [ -f "$old_csproj" ]; then
    mv "$old_csproj" "$new_csproj"
else
    echo "Error: .csproj file not found at '$old_csproj'"
    exit 1
fi

# 3. Заменяем содержимое во всех файлах
echo "Updating file contents..."
find "$folder_name" -type f \( -name "*.cs" -o -name "*.csproj" -o -name "*.txt" -o -name "*.md" \) | while read -r file; do
    if [ -f "$file" ]; then
        # Для macOS и Linux используем разные способы чтобы избежать проблем с кавычками
        if [[ "$OSTYPE" == "darwin"* ]]; then
            # macOS - используем временный файл
            sed "s/_0000\.Example/$namespace_name/g" "$file" > "$file.tmp"
            mv "$file.tmp" "$file"
        else
            # Linux - используем прямую замену
            sed -i "s/_0000\.Example/$namespace_name/g" "$file"
        fi
    fi
done

# 4. Добавляем проект в solution
echo "Adding project to solution..."
dotnet sln LeetCode.sln add "$folder_name/$folder_name.csproj"

if [ $? -eq 0 ]; then
    echo "Project successfully added to solution"
else
    echo "Error: Failed to add project to solution"
    exit 1
fi

echo "Done! Created: $folder_name"