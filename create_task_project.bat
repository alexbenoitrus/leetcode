@echo off
setlocal enabledelayedexpansion

:: Проверка наличия аргумента
if "%~1"=="" (
    echo Usage: %~nx0 "XXXX. Task name"
    echo Example: %~nx0 "29. Copy All Elements"
    exit /b 1
)

set "input=%~1"

:: Проверка существования исходной папки и solution файла
if not exist "_0000. Example" (
    echo Error: Source directory '_0000. Example' not found!
    exit /b 1
)

if not exist "LeetCode.sln" (
    echo Error: Solution file 'LeetCode.sln' not found!
    exit /b 1
)

:: Разбор входной строки
for /f "tokens=1,* delims=." %%a in ("%input%") do (
    set "number=%%a"
    set "task_name=%%b"
)

:: Удаление лишних пробелов
set "number=%number: =%"
set "task_name=%task_name:~1%"

:: Проверка формата числа
echo %number% | findstr /r "^[0-9][0-9]*$" >nul
if errorlevel 1 (
    echo Error: Invalid number format
    exit /b 1
)

:: Форматирование числа с ведущими нулями
set "formatted_number=0000%number%"
set "formatted_number=!formatted_number:~-4!"

:: Создание имени папки (с пробелами)
set "folder_name=_!formatted_number!. !task_name!"

:: Создание имени для замены в файлах (без пробелов и с капитализацией через PowerShell)
for /f "delims=" %%I in ('powershell -Command "[System.Threading.Thread]::CurrentThread.CurrentCulture.TextInfo.ToTitleCase('%task_name%'.ToLower())"') do set "capitalized_task_name=%%I"
set "namespace_name=_!formatted_number!.!capitalized_task_name: =!"

echo Creating task: !folder_name!
echo Namespace: !namespace_name!

:: 1. Копируем папку
echo Copying directory...
xcopy "_0000. Example" "!folder_name!\" /E /I /Q >nul

:: 2. Переименовываем .csproj файл
echo Renaming project file...
set "old_csproj=!folder_name!\_0000. Example.csproj"
set "new_csproj=!folder_name!\!folder_name!.csproj"

if exist "!old_csproj!" (
    ren "!old_csproj!" "!folder_name!.csproj"
) else (
    echo Error: .csproj file not found at '!old_csproj!'
    exit /b 1
)

:: 3. Заменяем содержимое во всех файлах
echo Updating file contents...
for /r "!folder_name!" %%f in (*.cs *.csproj *.txt *.md 2^>nul) do (
    if exist "%%f" (
        powershell -Command "(gc '%%f') -replace '_0000\.Example', '!namespace_name!' | sc '%%f'" >nul 2>&1
    )
)

:: 4. Добавляем проект в solution
echo Adding project to solution...
dotnet sln LeetCode.sln add "!folder_name!\!folder_name!.csproj"

if !errorlevel! equ 0 (
    echo Project successfully added to solution
) else (
    echo Error: Failed to add project to solution
    exit /b 1
)

echo Done! Created: !folder_name!
endlocal