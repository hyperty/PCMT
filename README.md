#### 为方便执行PCMark自动化测试，自动归纳测试结果，PCMarkTool可以在完成PCMark测试时，将多次跑分生成的XML结果自动归纳为一份CSV文档。

使用终端执行工具，需加上结果文件所在路径作为参数。例如：

```
C:\Users\i>PCMT.exe C:\PCMark10Results
```

这时，PCMT会自动完成下面几个操作：

1. 寻找参数路径中所有XML文件
2. 将所有XML文件自动转换成CSV文件，并保存在csv子目录中
3. 自动索引csv目录中所有CSV文件
4. 将所有csv目录下的文件合并为一个output.csv文件
