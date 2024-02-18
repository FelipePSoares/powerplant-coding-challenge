# powerplant-coding-challenge

## Pre requirements

- docker

## Testing the application

### Windows
1. Generate a https certificate
```
dotnet dev-certs https -ep %USERPROFILE%\.aspnet\https\aspnetapp.pfx -p <CREDENTIAL_PLACEHOLDER>
dotnet dev-certs https --trust
```
In the preceding commands, replace <CREDENTIAL_PLACEHOLDER> with a password. When using PowerShell, replace %USERPROFILE% with $env:USERPROFILE.

2. build the image using the command `docker build -t powerplant-coding-challenge .`
3. run the image using the command `docker run --rm -it -p 8887:8887 -p 8888:8888 -e ASPNETCORE_Kestrel__Certificates__Default__Password="<CREDENTIAL_PLACEHOLDER>" -e ASPNETCORE_Kestrel__Certificates__Default__Path="/https/aspnetapp.pfx" -v %USERPROFILE%\.aspnet\https:/https/ powerplant-coding-challenge`

NOTE: `<CREDENTIAL_PLACEHOLDER>` is a placeholder for the Kestrel certificates default password.

The password must match the password used for the certificate. When using PowerShell, replace %USERPROFILE% with $env:USERPROFILE.

4. Now, you can run the application on https://localhost:8888

### Linux

1. Generate a https certificate 
```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/aspnetapp.pfx -p <CREDENTIAL_PLACEHOLDER>
dotnet dev-certs https --trust
```

dotnet dev-certs https --trust is only supported on macOS and Windows. You need to trust certs on Linux in the way that is supported by your distribution. It is likely that you need to trust the certificate in your browser.

In the preceding commands, replace `<CREDENTIAL_PLACEHOLDER>` with a password.

2. build the image using the command `docker build -t powerplant-coding-challenge .`
3. run the image using the command `docker run --rm -it -p 8887:8887 -p 8888:8888 -e ASPNETCORE_Kestrel__Certificates__Default__Password="<CREDENTIAL_PLACEHOLDER>" -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx -v ${HOME}/.aspnet/https:/https/ powerplant-coding-challenge`

In the preceding code, replace `<CREDENTIAL_PLACEHOLDER>` with the password. The password must match the password used for the certificate.

4. Now, you can run the application on https://localhost:8888

## Author

Felipe Pires Soares

[![Linkedin Badge](https://img.shields.io/badge/-Felipe-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/felipepsoares/)](https://www.linkedin.com/in/felipepsoares/) 
