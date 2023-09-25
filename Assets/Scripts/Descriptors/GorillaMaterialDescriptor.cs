using System;
using UnityEngine;

namespace GorillaCosmetics.Data.Descriptors
{
	public class GorillaMaterialDescriptor : MonoBehaviour
	{
		public string MaterialName = "Material";

		public string AuthorName = "Author";

		public string Description = string.Empty;

		public bool CustomColors = false;

		public bool DisablePublicLobbies = false;
	}
}