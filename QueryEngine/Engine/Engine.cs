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
        public IEnumerable<string> EngineStart(string query, DataSource dataSource)
        {
            query = query.Replace("\'","\"");
            var splitters = new string[] { "from", "where", "select" };
            var strings = query.Split(splitters, StringSplitOptions.RemoveEmptyEntries);
            var typeNameTemp = strings[0].Trim();
            var typeName = typeNameTemp[0..^1];
            if (typeName == "User")
            {
                var p = Expression.Parameter(typeof(User), "User");
                return Compute(strings, dataSource, p);
            }
            else if (typeName.Trim() == "Order")
            {
                var p = Expression.Parameter(typeof(Order), "Order");
                return Compute(strings, dataSource, p);
            }
            else return new List<string>();
        }

        public IEnumerable<string> Compute(string[] strings, DataSource dataSource, ParameterExpression p)
        {
            var result = new List<string>();
            var e = System.Linq.Dynamic.Core.DynamicExpressionParser.ParseLambda(new[] { p }, null, strings[1]);
            foreach (var user in dataSource.Users)
            {
                var exists = e.Compile().DynamicInvoke(user);
                if ((bool)exists)
                {
                    foreach (var property in strings[2].Trim().Split(","))
                    {
                        var resultString = string.Empty;
                        switch (property.Trim())
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
            return result;
        }


    }
}
