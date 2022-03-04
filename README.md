WinShareEnum
============

WinShareEnum is an open source tool used to quickly scan networks for shared folders and to enumerate their permissions (looking for overly permissive access)

The ‘Interesting Files’ feature contains a (configurable) list of default words, wildcards and regular expressions to configure a search of all discovered shared folders, to focus analysis into any potentially dangerous storage of information (such as user credentials) based on the **filename(s)**.

The ‘File Contents’ feature contains a (configurable) list of default words, and can also contain wildcards & regular expressions, to search the contents of files within discovered shared folders, to focus analysis into any potentially dangerous storage of information (such as user credentials) based on the **file contents**.


download  https://github.com/m-xen/WinShareEnum/blob/master/Info/WinShareEnum.exe

![winshareenum running](https://i.postimg.cc/MKYypbRv/Win-Share-Enum.png)

options:
![winshareenum options](http://i.imgur.com/9y6V0WH.png?1)

  
The tool allows you to enter a network IPv4 range in several formats, to specify which networks should be searched for shared folders, e.g.  

CIDR >> 192.168.1.0/24  

Single Octet Range >> 192.168.1.0-255 (effectively /24)  

Multi Octet Range >> 192.168.0-255.0-255 (effectively /16)  

Regarding the ‘Use NULL Session’ option -> https://techcommunity.microsoft.com/t5/storage-at-microsoft/smb-and-null-sessions-why-your-pen-test-is-probably-wrong/ba-p/1185365