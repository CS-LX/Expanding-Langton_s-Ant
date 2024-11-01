~~这篇介绍是由程序开发者写的，chatGPT润色的~~

[English Version](#Expanding-Langton's-Ant)

# 兰顿蚂蚁的扩张

欢迎来到“兰顿蚂蚁的扩张”项目！这是一个基于兰顿蚂蚁算法的可视化程序，旨在展示蚂蚁如何在不同的颜色规则下移动并绘制轨迹。

## 目录

- [项目概述](#项目概述)
- [使用说明](#使用说明)
- [操作规则](#操作规则)
- [预设操作](#预设操作)
- [开发者信息](#开发者信息)

## 项目概述

本项目通过兰顿蚂蚁算法的可视化展示，利用 WinForms 和 OpenGL 技术创建一个互动的图形界面。用户可以自定义蚂蚁的运动规则，并实时观察蚂蚁在不同规则下的运动轨迹。

## 使用说明

1. **下载与解压**  
  下载程序压缩包后，将其解压到本地。你会发现名为 `Expanding Langton_s And.exe` 的可执行文件（原本应为“Ant”）。
  
2. **启动程序**  
  双击可执行文件，程序将启动，显示一个黑色窗口和一个设置窗口。
  
3. **控制蚂蚁**
  
  - 点击 ▶️ 按钮开始运行蚂蚁。
  - 点击 ⏸️ 按钮暂停蚂蚁。
  - 点击 ⏹️ 按钮重置蚂蚁。

## 操作规则

蚂蚁的移动行为是基于预设的颜色规则。设置窗口中会显示当前的行动规则列表。你可以：

- 点击任意一条规则，使用下方的“转向”按钮切换蚂蚁的转向（左转或右转）。
- 点击 "+" 或 "-" 按钮添加或删除行动规则。

如果想批量修改行动规则，可以在程序开始运行前编辑目录下的 `Operations.txt` 文件。文件格式如下：

`R G B L/R`

- RGB 值范围为 0~255。
- L 表示向左转，R 表示向右转。

程序启动时会自动读取 `Operations.txt` 中的内容作为蚂蚁的行动规则。

## 预设操作

在 `OperationsPrefab` 文件夹中提供了一系列操作预设，使用这些预设可以让蚂蚁的轨迹形成美丽的图形。只需将文件夹内的内容复制到 `Operations.txt` 文件中，再启动程序，即可观察蚂蚁绘制出绚丽的图形！

## 开发者信息

本程序使用 WinForms 基于 .NET 8.0 开发，绘图部分采用 OpenGL 技术。以下是程序的一些关键组件：

- `GLMakesMeMad.dll`: 对 OpenGL 的简单封装，源代码可在 [这里](https://github.com/CS-LX/GLMakesMeMad) 查阅。
- `CLITestsMyGL.dll`: 使用 C++/CLI 编写的中间库，用于连接 OpenGL 和 WinForms，源代码同样可在 [这里](https://github.com/CS-LX/GLMakesMeMad) 查阅。

# Expanding Langton's Ant

Welcome to the "Expanding Langton's Ant" project! This is a visualization program based on the Langton's Ant algorithm, designed to demonstrate how the ant moves and draws paths under different color rules.

## Table of Contents

- [Project Overview](#project-overview)
- [Usage Instructions](#usage-instructions)
- [Operation Rules](#operation-rules)
- [Preset Operations](#preset-operations)
- [Developer Information](#developer-information)

## Project Overview

This project visualizes the Langton's Ant algorithm using WinForms and OpenGL to create an interactive graphical interface. Users can customize the ant's movement rules and observe the ant's trajectory in real-time under different rules.

## Usage Instructions

1. **Download and Extract**  
  After downloading the program zip file, extract it locally. You will find an executable file named `Expanding Langton_s And.exe` (it should have been named "Ant").
  
2. **Start the Program**  
  Double-click the executable file to start the program, which will display a black window and a settings window.
  
3. **Control the Ant**
  
  - Click the ▶️ button to start the ant.
  - Click the ⏸️ button to pause the ant.
  - Click the ⏹️ button to reset the ant.

## Operation Rules

The ant's movement behavior is based on predefined color rules. The settings window displays the current action rules list. You can:

- Click any rule and use the "Turn" button below to switch the ant's direction (left or right).
- Click the "+" or "-" buttons to add or remove action rules.

If you want to modify action rules in bulk, you can edit the `Operations.txt` file in the program directory before running the program. The file format is as follows:

`R G B L/R`

- RGB values range from 0 to 255.
- L means turn left, R means turn right.

The program will automatically read the contents of `Operations.txt` as the ant's action rules upon startup.

## Preset Operations

A series of preset operations are provided in the `OperationsPrefab` folder. Using these presets, you can create beautiful patterns with the ant's trajectory. Simply copy the contents of the folder into the `Operations.txt` file and start the program to see the ant drawing stunning graphics!

## Developer Information

This program is developed using WinForms based on .NET 8.0, with the drawing part utilizing OpenGL technology. Here are some key components of the program:

- `GLMakesMeMad.dll`: A simple wrapper for OpenGL; source code can be found [here](https://github.com/CS-LX/GLMakesMeMad).
- `CLITestsMyGL.dll`: An intermediate library written in C++/CLI for connecting OpenGL and WinForms; source code can also be found [here](https://github.com/CS-LX/GLMakesMeMad).
