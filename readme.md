# Описание
Этот проект позволяет легко общаться с GPT-3.5 Turbo, а также генерировать изображения! Данный проект легко интегрируется в любой код на C#.
# Использование
1. Клонировать репозиторий:  
```git clone https://github.com/Processori7/FreeAiClient.git```
2. Далее копировать файл FreeAI.cs в ваш проект.
3. Подключить файл: using FreeAI;
4. Использовать нужный класс.
# Примеры:
## Генерация текста:  
```var FreeGPTAns = await FreeGPT.ASK("Как дела?");
Console.WriteLine(FreeGPTAns); //Все отлично, спасибо! Как я могу помочь вам сегодня? ```  
## Генерация картинок:  
```var PolinationsAns = await Pollinations.Generate("Красивая природа");
Console.WriteLine(PolinationsAns); //ans: img\63f21636-f813-4dd1-8b71-f4ec2f130f79.png```  

Аргументы:
-prompt(обязательно): Текстовое описание изображения, которое вы хотите создать.  
- model(необязательно): Модель, используемая для генерации. Варианты: «флюс» или «турбо». По умолчанию: «турбо»  
- seed(опционально): Seed для воспроизводимых результатов. По умолчанию: случайный  
- width(необязательный): Ширина сгенерированного изображения. По умолчанию: 1024  
- height(необязательно): Высота сгенерированного изображения. По умолчанию: 1024  
- nologo(опционально): установите значение 'true', чтобы отключить рендеринг логотипа  
- nofeed(опционально): установите значение 'true', чтобы изображение не появлялось в общедоступной ленте  
- enhance(опционально) : установите значение "true" или "false", чтобы включить или отключить улучшение подсказок (передает подсказки через LLM для добавления деталей)  
- folder(опционально) : папка для сохранения изображения. По умолчанию: img
----------------------------------------------------------------------------------------------------
# Description
This project makes it easy to communicate with GPT-3.5 Turbo, as well as generate images! This project can be easily integrated into any C# code.
# Usage
1. Clone the repository:  
```git clone https://github.com/Processori7/FreeAiClient.git```
2. Next, copy the FreeAI file.cs to your project.
3. Connect the file: using FreeAI;
4. Use the appropriate class.
# Examples:
## Text generation:  
```var FreeGPTAns = await FreeGPT.ASK("How are you?");
Console.WriteLine(FreeGPTAns); //Everything is fine, thanks! How can I help you today? ```  
## Image generation:   
```var PolinationsAns = await Pollinations.Generate("Beautiful nature");
Console.WriteLine(PolinationsAns); //ans: img\63f21636-f813-4dd1-8b71-f4ec2f130f79.png```  

Arguments:
-prompt(required): A text description of the image you want to create.  
- model(optional): The model used for generation. Options: "flux" or "turbo". Default: "turbo"  
- seed(optional): Seed for reproducible results. Default: random  
- width(optional): The width of the generated image. Default: 1024  
- height(optional): The height of the generated image. Default: 1024  
- nologo(optional): Set the value to 'true' to disable logo rendering  
- nofeed(optional): Set the value to 'true' so that the image does not appear in the public feed  
- enhance(optional) : Set the value to "true" or "false" to enable or disable hint enhancement (transmits hints via LLM to add details)  
- folder(optional) : a folder for saving the image. Default: img