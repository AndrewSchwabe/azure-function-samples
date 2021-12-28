/*
 * Summary : Basic implementation of an Azure Function.
 *
 * Params:
 *   * context : The context of the Azure Function
 *   * req : The context of the HTTP request
 *
 * NOTES:
 *   1. Compared to the C# implementation, there is no binding information in this file for the Azure function
 *   2. All function binding configuration can be found in function.json file
 *   3. Only 1 function can be defined per a project : https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-node?tabs=v2#folder-structure
 */
module.exports = async function (context, req) {
  const responseMessage = { currentDateTime: new Date() };

  context.res = {
    body: responseMessage,
  };
};