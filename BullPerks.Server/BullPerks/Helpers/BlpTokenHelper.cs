using Nethereum.Web3;
using System.Numerics;

namespace BullPerks.Helpers
{
    public class BlpTokenHelper
    {
        private readonly Web3 _web3;
        private readonly string _abi;
        private readonly string _tokenAddress;

        public BlpTokenHelper(string web3Url, string abi, string tokenAddress)
        {
            _web3 = new Web3(web3Url);
            _abi = abi;
            _tokenAddress = tokenAddress;
        }

        public async Task<BigInteger> GetTotalSupplyAsync()
        {
            var contract = _web3.Eth.GetContract(_abi, _tokenAddress);
            var totalSupplyFunction = contract.GetFunction("totalSupply");
            var totalSupply = await totalSupplyFunction.CallAsync<BigInteger>();
            return totalSupply;
        }

        public async Task<BigInteger> GetNonCirculatingSupplyAsync(string[] nonCirculatingAddresses)
        {
            BigInteger nonCirculatingSupply = BigInteger.Zero;

            foreach (var address in nonCirculatingAddresses)
            {
                var balance = await GetBalanceOfAsync(address);
                nonCirculatingSupply += balance;
            }

            return nonCirculatingSupply;
        }

        private async Task<BigInteger> GetBalanceOfAsync(string address)
        {
            var contract = _web3.Eth.GetContract(_abi, _tokenAddress);
            var balanceOfFunction = contract.GetFunction("balanceOf");
            var balance = await balanceOfFunction.CallAsync<BigInteger>(address);
            return balance;
        }
    }
}
