#Course Enrollment System
To use CES, copy `libmysql.dll` and `libmysql.lib` from `utilities/` to `C:\Windows\System32` folder.  
Then run CES.exe or CESadmin.exe in `bin/` folder.  

*Note* Pre-compiled CES.exe and CESadmin.exe only run on 64bit Windows 7 or later. .Net Framework 4.5 is also need. If you don't have .Net Framwork 4.5 installed, you can download it [here](http://www.microsoft.com/zh-cn/download/details.aspx?id=30653). You may also need to change the default database server address in the given source code.

To build them manually, download [MySQL Connectors/C++](http://dev.mysql.com/downloads/connector/cpp/) and compile all components using C source files in `src/C Sourse`. After building all the components, copy them to your VS Debug or Release folder where your final CES.exe will be. Finally, open the .sln projects in `src/GUI/CES` or `src/GUI/CESadmin`, set up your Solution Platforms and run.


To import or restore sample database, use 
```bash
	mysql -u YOURUSERNAME -p YOURPASSWORD Courses < bak.sql
```

###Some screenshots  
![1](./doc/img/1.PNG)

![2](./doc/img/2.PNG)

![3](./doc/img/3.PNG)

![4](./doc/img/4.PNG)
