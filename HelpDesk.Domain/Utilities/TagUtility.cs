﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Utilities
{
    public static class TagUtility
    {
        /// <summary>
        /// Gets the tags from a comma separated string list of tags.
        /// </summary>
        /// <param name="tagString">The tag list string.</param>
        /// <returns></returns>
        public static string[] GetTagsFromString(string tagString)
        {

            List<string> returnTags = new List<string>();
            if (!string.IsNullOrEmpty(tagString))
            {
                string[] tags = tagString.Split(',');
                foreach (string t in tags)
                {
                    var formattedTag = t.ToLowerInvariant().Trim();
                    if (!string.IsNullOrEmpty(formattedTag) && !returnTags.Contains(formattedTag))
                    {
                        returnTags.Add(formattedTag);
                    }
                }
            }
            return returnTags.ToArray();
        }
    }
}
