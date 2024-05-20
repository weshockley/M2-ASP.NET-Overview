# Setup Instructions

1. Explain the configuration set in appsettings.json file

2. Explain the serialization changes needs to be done in Program.cs file.

3. Pulibhs the app using Release configuration as shown below

   ```powershell
   dotnet publis -c Release
   ```

4. Publish process should create `NativeAOTWebAPI\bin\Release\net8.0\win-x64` folder on Windows X64 machine.
5. Open native folder under win-x64 machine and run the NativeAOTWebAPI.dll

6. Application will launch the API on port 5000

7. Open http://localhost:5000 on the browser and check the ToDo item rendered.
