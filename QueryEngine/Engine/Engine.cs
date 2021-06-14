using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic;

namespace QueryEngine.Engine
{
    public sealed class Engine
    {
        public IEnumerable<string> Compute(string query, DataSource dataSource)
        {
            var result = new List<string>();
            var splitters = new string[] { "from", "where", "select" };
            var strings = query.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            var typeName = strings[0].Trim().Substring(0, strings[0].Length - 1);
            if (typeName == "User")
            {
                var p = Expression.Parameter(typeof(User), "User");
                var e = System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(new[] { p }, null, strings[1]);
                foreach (var user in dataSource.Users)
                {
                    var exists = e.Compile().DynamicInvoke(user);
                    if ((bool)exists)
                    {
                        foreach (var property in strings[2].Trim().Split(","))
                        {
                            var resultString = string.Empty;
                            switch (property)
                            {
                                case "FullName":
                                    {
                                        resultString = "FullName: " + user.FullName;
                                        break;
                                    }
                                case "Age":
                                    {
                                        resultString = "Age: " + user.Age;
                                        break;
                                    }
                                case "Email":
                                    {
                                        resultString = "Email: " + user.Email;
                                        break;
                                    }
                            }
                            result.Add(resultString);
                        }
                    }
                }
            }
            return result;
        }
    }
}
