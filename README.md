# Sungero.Plugins.Templates
В репозитории находятся шаблоны проектов для разработки плагина подписания к системе DirectumRX.
Шаблоны проектов созданы в Microsoft Visual Studio 2017.

Базовая информация об использовании электронной подписи приведена в документации к системе.
Плагины подписания поддерживаются, начиная с DirectumRX 3.3. Ограничения:
* Плагины подписания не поддерживаются в десктоп-клиенте.
* Клиентский плагин подписания поддерживается в Microsoft Windows 7 и выше, Microsoft Windows Server 2008 R2 и выше.
* Ветка master совместима с платформой Sungero версии 3.3.8.0019 и выше. Для платформы Sungero версии 3.3.8.0018 и ниже необходимо переключиться на ветку 3.3.8.0018.

### Как разработать плагин подписания
1. В проектах `ServerCryptographyPlugin`, `ClientCryptographyPlugin` измените имя сборки на свое (например, на `MyServerCryptographyPlugin`, `MyClientCryptographyPlugin`)
2. Сгенерируйте уникальный идентификатор (GUID) плагина (например на сайте https://www.guidgenerator.com/), пропишите его в свойстве `CryptographyPlugin.Id` класса серверного плагина и в файле `ClientPlugin.targets` клиентского плагина;
3. Реализуйте **серверный плагин**. Для этого: 
    * Реализуйте методы класса `Signer`: `SignData()`, `TryLoadPrivateKey()` и `VerifySignature()`. При необходимости модифицируйте остальные методы класса.
    * При необходимости модифицируйте методы класса `CryptographyPlugin`. Укажите нужный идентификатор алгоритма подписания в данном классе (поле `SignAlgorithmId`).
    * При необходимости создайте свой алгоритм хеширования с помощью класса `HashAlhorithmExample`.
    * Взаимодействие между классами описано в начале модуля `CryptographyPlugin.cs`.
4. Реализуйте **клиентский плагин**. Для этого:
    * Укажите нужный идентификатор алгоритма подписания в классе `Signer` (поле `AlgorithmId`).
    * Модифицируйте методы класса `Signer`. 
5. Соберите проект. В папке *out* в корне проекта появятся папки *Client* и *Server*, содержащие файлы клиентского и серверного плагинов соответственно.
6. Дополнительные библиотеки, требующие распространения вместе с плагином, включите в соответствующий проект. Они автоматически должны попасть в zip-архив. 
7. Подключите серверный плагин к DirectumRX:
    * Создайте папку для хранения плагина, например, *D:\Plugins*. При обновлении системы DirectumRX может изменяться содержимое ее папок. Поэтому рекомендуется создать отдельную папку.
    * В конфигурационных файлах *_ConfigSettings.xml* всех серверных компонент в параметре PLUGINS_ZIP_PATH укажите путь к папке с плагинами, например:  
    ```<var name="PLUGINS_ZIP_PATH" value="D:\Plugins" />```
    * Скопируйте архив с серверным плагином в указанную папку.
    * Если необходимо передать дополнительные настройки в плагин, укажите их в тех же конфигурационных файлах *_ConfigSettings.xml*, где производилась настройка пути к папке с плагинами. Формат секции с настройками: 
      ```XML
      <block name="PLUGINS">
        <plugin id="<ид_плагина>"
          exampleSetting="Example value"
          otherSetting="Other value" />
      </block>
      ```
    Чтение настроек в плагине выполняется в методе `CryptographyPlugin.ApplySettings()`.
8. Подключите клиентский плагин к DirectumRX. Клиентский плагин используется в веб-агенте при работе веб-клиента DirectumRX. Для подключения:
    * Скопируйте файлы из папки *out\Client* в папку плагинов веб-агента на сервере приложений, например, в  
    ```C:\inetpub\wwwroot\Client\content\WebAgent\plugins\```
    * Запустите утилиту *packages_manifest_updater.exe* из папки *PackagesManifestUpdater* веб-агента на сервере приложений, например, из  
    ```C:\inetpub\wwwroot\Client\content\WebAgent\PackagesManifestUpdater```
### Особенности формирования и проверки электронной подписи в DirectumRX
* Электронная подпись формируется в формате CAdES-BES.
* При подписании сертификатом в веб-клиенте само подписание выполняется на стороне клиента, но данные для подписи (подписываемые атрибуты подписи) формируются на сервере приложений.
* Сервер приложений работает в 64-битном окружении, а веб-агент - в 32-битном. Это необходимо учитывать, если для работы плагинов нужны COM-компоненты и их регистрация.
* При необходимости подписание может быть выполнено на стороне сервера. В этом случае закрытый ключ должен быть доступен на сервере.
