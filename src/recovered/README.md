# 恢复的 C# 脚本

这里保留从现存 Windows 成品中恢复的游戏逻辑：Cherry Run 11 个文件，Ghostlight Grove 2 个文件。恢复工具为 [ILSpy 9.1.0.7988](https://www.nuget.org/packages/ilspycmd/9.1.0.7988)，只处理两份自定义 `Assembly-CSharp.dll`，没有反编译引擎和第三方依赖。

原始 `.cs` 和工程目录尚未找回，因此这些文件不包含原注释、原目录结构或完整资源关联。每个文件顶部均标注了恢复来源，原游戏程序集没有被修改或替换。

## Cherry Run

| 文件 | 逻辑内容 |
| --- | --- |
| [PlayerMovement.cs](cherry-run/PlayerMovement.cs) | 读取 Horizontal／Jump 输入，控制速度、落地判断和动画状态。 |
| [PlayerLife.cs](cherry-run/PlayerLife.cs) | 判断陷阱、设置死亡状态、还原进入关卡时的计数并重新加载场景。 |
| [Item_Collector.cs](cherry-run/Item_Collector.cs) | 樱桃触发、销毁、计数及 UI 更新。 |
| [AllControl.cs](cherry-run/AllControl.cs) | 保存共享分数的 GameManager。 |
| [Finish.cs](cherry-run/Finish.cs) | 终点判定与下一场景切换。 |
| [StartMenu.cs](cherry-run/StartMenu.cs) | 开始页入口。 |
| [EndMenu.cs](cherry-run/EndMenu.cs) | 结束页入口。 |
| [Camera.cs](cherry-run/Camera.cs) | 跟随角色的 2D 镜头。 |
| [Rotate.cs](cherry-run/Rotate.cs) | 物体旋转。 |
| [StickyPlatfrom.cs](cherry-run/StickyPlatfrom.cs) | 角色与平台的父子关系设置。文件名沿用程序集中的拼写。 |
| [WayPointFollower.cs](cherry-run/WayPointFollower.cs) | 平台按路径点移动。 |

## Ghostlight Grove

| 文件 | 逻辑内容 |
| --- | --- |
| [CameraMovement.cs](ghostlight-grove/CameraMovement.cs) | 鼠标右键拖动旋转，滚轮改变距离，俯仰角和距离限位，以及插值阻尼。 |
| [FacingCamera.cs](ghostlight-grove/FacingCamera.cs) | 让子物体的旋转跟随主镜头。 |

脚本中的输入名和参数默认值可以直接阅读；实际键位映射、Inspector 覆盖值、组件挂载及动画事件仍需场景资料或实际运行核对。

## 编译检查

使用 Windows .NET Framework 的 C# 编译器 4.8.9232.0（C# 5），两组脚本分别引用各自成品 `Managed` 下除 `Assembly-CSharp*` 外的依赖进行库编译。实际参数为 `/nologo /noconfig /nostdlib+ /target:library`，校验 DLL 仅写入本地辅助目录。

- Cherry Run：编译成功；`Camera.player`、`Item_Collector.cherriesText`、`PlayerMovement.jumpableGround` 和 `WayPointFollower.waypoints` 共 4 条 CS0649，表示这些字段在代码中没有赋值。它们带有 Unity 序列化标记，是否在场景里配置正确尚未验收。
- Ghostlight Grove：编译成功，无警告。

两组脚本来自不同游戏，应分别处理。此项检查证明恢复代码能够在对应依赖下编译，不代表场景、动画事件、资源绑定已恢复，也不代表游戏玩法已经测试通过。

## 来源程序集校验

| 游戏 | 原自定义程序集 SHA-256 |
| --- | --- |
| Cherry Run | `ef6a595dec3388f50f39f2521d5e05e3a7b7f4266a13109d26eae5a517b0eec8` |
| Ghostlight Grove | `600e327160dddf59df0077297c66c923c231de33a678ef81f01906b77cc295b5` |

程序集位于各自成品的 `*_Data/Managed/Assembly-CSharp.dll`；其他成品文件的校验值记录在 [build-manifest.json](../../games/build-manifest.json)。
