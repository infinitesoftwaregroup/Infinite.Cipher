# :rat::closed_lock_with_key: Infinite

![forthebadge](https://raw.githubusercontent.com/infinitesoftwaregroup/Infinite.Cipher/main/.github/images/made-with-c-sharp.svg)
![forthebadge](https://raw.githubusercontent.com/infinitesoftwaregroup/Infinite.Cipher/main/.github/images/built-with-love.svg)

A .NET Core Tool to encrypt and decrypt files using AEAD AES-256-GCM, as well as generate an encryption key.

The tool was created to help encrypt configuration files for use with the .NET Core projects using the [Infinite.AddEncryptedJsonToConfiguration](https://github.com/infinitesoftwaregroup/Infinite.AddEncryptedJsonToConfiguration.git) library. Infinite can be used as a stand-alone tool to encrypt and decrypt files.

## Installation

Download and install the [.NET Core 6.0 SDK](https://www.microsoft.com/net/download)
or newer. Once installed, run the following command to run OtterKeys:

```bash
dotnet tool install -g Infinite.Cipher
```

## Usage

Once installed you can call Infinite.Cipher from the command line:

```bash
CipherTool --help
```

> You can use the --help option to get more details about the commands and
their options.

### Creating a new encryption key

> Creating a new encryption key is as easy as typing:

```bash
CipherTool generate
```

CipherTool will output the encryption key in the console.

The encryption key should be stored securely. Each of your projects/products should have it's own unique key if the key is used to encrypt a configuration file. Never check the encryption key into a source control.

### Encrypt a file

You can encrypt a file using the following command:

Usage: `CipherTool encrypt -k {Key} {FileName}`

The file is replaced. Add the `-c` option to output the encrypted content to your console instead of writing to the file system.

### Decrypt a file

You can decrypt a file using the following command:

Usage: `CipherTool decrypt -k {Key} {FileName}`

The file is replaced. Add the `-c` option to output the decrypted content to your console instead of writing to the file system.
