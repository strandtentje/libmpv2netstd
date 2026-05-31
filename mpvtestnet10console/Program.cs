using LibMpvWrapper;

Console.WriteLine("Hello, World!");

var factory = new MpvPlayerFactory();
using var player = factory.CreatePlayer(nint.Zero, PlaylistLifecycle.PauseAfterEnd);

player.PlayNow("/home/rob/Video's/205.jpeg");
player.IsFullscreen = true;
player.FullscreenMonitor = 0;

Console.ReadLine();


