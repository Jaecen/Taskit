﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Taskit.Web.Models
{
	public class Attribute
	{
		public virtual int Id { get; set; }
		public virtual string Key { get; set; }
		public virtual string Value { get; set; }
		public virtual int DisplayOrder { get; set; }
	}
}