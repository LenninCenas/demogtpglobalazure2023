# Chatbot con OpenAI API en Bot Framework

Este chatbot utiliza la API de OpenAI (gpt-3.5-turbo) para proporcionar respuestas a los mensajes del usuario.

## Configuración

Antes de poder ejecutar este bot, debe seguir los siguientes pasos:

1. Regístrese en la [plataforma de OpenAI](https://platform.openai.com/signup) para obtener una clave API.

2. Copie la [clave API de OpenAI](https://platform.openai.com/account/api-keys) en el archivo `EchoBot.cs` en `string openaiApiKey = "";`

## Ejecución
- Abra el proyecto en Visual Studio.
- Ejecute el proyecto.
- Pruebe en Bot Framework Emulator.

[![Alt del video](https://img.youtube.com/vi/GHfxnb6FGV4/0.jpg)](https://www.youtube.com/watch?v=GHfxnb6FGV4)

## Uso
El bot de chat escucha los mensajes del usuario y los utiliza como entrada para la API de OpenAI para generar una respuesta. El bot luego envía la respuesta generada al usuario.

## Contribución
Si desea contribuir a este proyecto, puede enviar un pull request o crear una nueva issue en Github. Se aceptan sugerencias de mejora, errores o nuevas características.
