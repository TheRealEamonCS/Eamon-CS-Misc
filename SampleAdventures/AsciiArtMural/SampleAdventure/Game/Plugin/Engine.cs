﻿
// Engine.cs

// Copyright (c) 2014+ by Michael Penner.  All rights reserved.

using System.Reflection;
using Eamon;
using static SampleAdventure.Game.Plugin.Globals;

namespace SampleAdventure.Game.Plugin
{
	public class Engine : EamonRT.Game.Plugin.Engine, Framework.Plugin.IEngine
	{
		public virtual string MuralData { get; set; }

		public override RetCode LoadPluginClassMappings()
		{
			RetCode rc;

			rc = base.LoadPluginClassMappings();

			if (rc != RetCode.Success)
			{
				goto Cleanup;
			}

			rc = LoadPluginClassMappings01(Assembly.GetExecutingAssembly());

		Cleanup:

			return rc;
		}

		public Engine()
		{
			// You can manually create ASCII art, find some online (with a permissive license), or use a generator like that found
			// at https://www.ascii-art-generator.org/.  Then copy the ASCII artwork and encode it with a base-64 converter like that
			// found at https://www.base64encode.org/.  Always use LF (Unix) line endings since this works with both Windows and Unix.
			// Finally, take the encoded sequence and put it in a verbatim string as shown below.  This kind of artwork is best viewed
			// with a fixed-width font.

			// The following was generated from an image by Tua Xiong found at https://www.asciiart.eu/mythology/fantasy.

			MuralData = @"ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAvfA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHxcfA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHx8fA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHx8fA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHx8fA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHx8fA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHx8fA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHx8fA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIH4tW3tvfV0tfg0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHwvfA0KICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIHwvfA0KICAgICAgICAgICAgIC8vL35gICAgICB8XFxfICAgICAgICAgIGAwJyAgICAgICAgID1cXFxcICAgICAgICAgLiAuDQogICAgICAgICAgICAsICB8PScgICwpKVxffCB+LV8gICAgICAgICAgICAgICAgICAgIF8pICBcICAgICAgXy9fL3wNCiAgICAgICAgICAgLyAsJyAsOygoKCgoKCAgICB+IFwgICAgICAgICAgICAgICAgICBgfn5+XC1+LV8gL34gKF8vXA0KICAgICAgICAgLycgLX4vfikpKSkpKSknXF8gICBfLycgICAgICAgICAgICAgICAgICAgICAgXF8gIC8nICBEICAgfA0KICAgICAgICAoICAgICAgICgoKCgoKCB+LS8gfi0vICAgICAgICAgICAgICAgICAgICAgICAgICB+LTsgIC8gICAgXC0tXw0KICAgICAgICAgfn4tLXwgICApKScnICAgICcpICBgICAgICAgICAgICAgICAgICAgICAgICAgICAgIGB+flxfICAgIFwgICApDQogICAgICAgICAgICAgOiAgICAgICAgKF8gIH5cICAgICAgICAgICAsICAgICAgICAgICAgICAgICAgICAvfn4tICAgICAuLw0KICAgICAgICAgICAgICBcICAgICAgICBcXyAgICktLV9fICAvKF8vKSAgICAgICAgICAgICAgICAgICB8ICAgICkgICAgKXwNCiAgICBfX18gICAgICAgfF8gICAgIFxfXy9+LV9fICAgIH5+ICAgLCcgICAgICAvLF87LCAgIF9fLS0oICAgXy8gICAgICB8DQogIC8vfn5cYFwgICAgLycgfn5+LS0tLXwgICAgIH5+fn5+fn5+JyAgICAgICAgXC0gICgofn4gICAgX18tfiAgICAgICAgfA0KKCgoKSAgIGBcYFxfKF8gICAgIF8tfn4tXCAgICAgICAgICAgICAgICAgICAgICBgYH5+IH5+fn5+fiAgIFxfICAgICAgLw0KICkpKSAgICAgfi0tLS0nICAgLyAgICAgIFwgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICkgICAgICAgKQ0KICAoICAgICAgICAgO2B+LS0nICAgICAgICA6ICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICBfLSAgICAsOzsoDQogICAgICAgICAgICB8ICAgIGBcICAgICAgIHwgICAgICAgICAgICAgICAgICAgICAgICAgICAgIF8tfiAgICAsOzs7OykNCiAgICAgICAgICAgIHwgICAgLydgXCAgICAgOyAgICAgICAgICAgICAgICAgICAgICAgICAgXy1+ICAgICAgICAgIF8vDQogICAgICAgICAgIC9+ICAgLyAgICB8ICAgICkgICAgICAgICAgICAgICAgICAgICAgICAgLzs7OycnICAsOzs6LX4NCiAgICAgICAgICB8ICAgIC8gICAgIC8gfCAvICAgICAgICAgICAgICAgICAgICAgICAgIHw7OycgICAsJycNCiAgICAgICAgICAvICAgLyAgICAgfCAgXFx8ICAgICAgICAgICAgICAgICAgICAgICAgIHwgICAsOyggICAgLVR1YSBYaW9uZw0KICAgICAgICBfLyAgLycgICAgICAgXCAgXF8pICAgICAgICAgICAgICAgICAgIC4tLS1fX1xfICAgIFwsLS0uX19fX19fXw0KICAgICAgICggKXwnICAgICAgICAgKH4tX3wgICAgICAgICAgICAgICAgICAgKDs7JyAgOzs7fn5+LycgYDs7fCAgYDs7O1wNCiAgICAgICAgKSBgXF8gICAgICAgICB8LV87Oy0tX18gICAgICAgICAgICAgICB+fn4tLS0tX18vJyAgICAvJ19fX19fX18vDQogICAgICAgIGAtLS0tJyAgICAgICAoICAgYH4tLV8gfn5+OzstLS0tLS0tLS0tLS1+fn5+fiA7OzsnXy8nDQogICAgICAgICAgICAgICAgICAgICBgfn5+fn5+fn4nfn5+LS0tLS0uLi4uX19fOzs7X19fXy0tLX5+";

			// The @@001 token in Module description will be replaced by a string returned from MacroFunc with key == 1

			MacroFuncs.Add(1, () => System.IO.Path.DirectorySeparatorChar.ToString());
		}
	}
}
