﻿// Original Work Copyright (c) Ethan Moffat 2014-2015
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using System;
using System.Drawing;

namespace EOLib.Graphics
{
	public interface INativeGraphicsLoader : IDisposable
	{
		Bitmap LoadGFX(GFXTypes file, int resourceValue);
	}
}