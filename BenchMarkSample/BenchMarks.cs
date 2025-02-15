using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace BenchMarkSample
{
    public record IntWrapper(int Number);

    [MemoryDiagnoser]
    public class BenchMarks
    {
        private readonly List<int> _rawNumbers;
        public readonly List<IntWrapper> _wrapNumbers;
        public BenchMarks()
        {
            _rawNumbers  = Enumerable.Range(1, 1000).ToList();
            _wrapNumbers = Enumerable.Range(1, 1000).Select(i => new IntWrapper(i)).ToList();
        }

        [Benchmark]
        public int FindRaw()
        {
            return _rawNumbers.Find(x => x == 500)!;
        }

        [Benchmark]
        public int FirstOrDefalultRaw()
        {
            return _rawNumbers.FirstOrDefault(x => x == 500)!;
        }

        [Benchmark]
        public int SingleOrDefalultRaw()
        {
            return _rawNumbers.SingleOrDefault(x => x == 500)!;
        }

        [Benchmark]
        public IntWrapper FindWrap()
        {
            return _wrapNumbers.Find(x => x.Number == 500)!;
        }

        [Benchmark]
        public IntWrapper FirstOrDefalultWrap()
        {
            return _wrapNumbers.FirstOrDefault(x => x.Number == 500)!;
        }

        [Benchmark]
        public IntWrapper SingleOrDefalultWrap()
        {
            return _wrapNumbers.SingleOrDefault(x => x.Number == 500)!;
        }
    }
}
