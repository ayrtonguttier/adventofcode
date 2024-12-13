Stream stdin = Console.OpenStandardInput();

StreamReader reader = new StreamReader(stdin);
var line = await reader.ReadLineAsync();
if (line is null) return -1;

List<int> leftPart = new List<int>();
List<int> rightPart = new List<int>();


while (line is not null)
{
  if (line is null) continue;
  var left = "";
  var right = "";
  var lr = false;

  for (int i = 0; i < line.Length; i++)
  {
    if (line[i] == ' ')
    {
      lr = true;
      continue;
    }
    if (lr)
    {
      right += line[i];
    }
    else
    {
      left += line[i];
    }
  }


  leftPart.Add(int.Parse(left));
  rightPart.Add(int.Parse(right));

  line = await reader.ReadLineAsync();
}


var leftOrdered = leftPart.OrderBy(x => x);
var rightOrdered = rightPart.OrderBy(x => x);

var result = leftOrdered.Zip(rightOrdered, (l, r) => new Pair(l, r, Math.Abs(r - l)));
var sum = 0;
foreach (var item in result)
{
  Console.WriteLine(item);
  sum += item.Distance;
}

Console.WriteLine(sum);

return 0;


record struct Pair(int Left, int Right, int Distance);
