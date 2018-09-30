#Bauer Network
#Personal Site
This is my personal site and a small system that I use to control personal finnances.

As far as I'm aware, there are no proprietary code here, every resource our library was obtained for free on internet, however theirs specific licenses still apply if anyone desires to use my code by any means.

#About the comments
Please, be patient with the comments
My system operates in Brazilian Portuguese and it automaticaly tries to 'help' me changing some words believing I typed it wrong... When I see it, I fix, but it may have some lose portuguese words lost through the system... :(

#Tools
by July, 2, 2018 these are the tools I'm using for development;
- Visual Studio Code;
- Visual Studio 2017 Community Edition (Scaffold and Nuget Package, basicaly);
- Git Hub;
- Microsoft One Note (to manage dev progress);
- SQL Management Studio;


#My Namming Convention
Unless it's a library or tool with very specific naming conventions, I'll use what follows.
- Classes will be CamelCase;
- Properties of basic types (string, int, bool, etc) will be mixedCase or compoundCase
- Properties of custom classes will be CamelCase and have the name similar to the type name
    - Exceptions are for private properties that'll use _mixedCase
        - And when i'm using the Interface as a type.
- Parameters will have similar ruling then Properties;
- Tables and models are CamelCase and start with it's main purpose.
    Ent from entity for basic models;
    Rel for relation tables on 'n' to '1' or 'n' to 'n';
    Obj from Object for logical our bussiness only models;


#Some personal code ruling
I don't like to let the connection string with obvious names and in configuration files. For this project, since it'll be 'open', I'll use simple string transformation to let it less obviously and inside a class so it'll be inside the dll once the project is compiled;