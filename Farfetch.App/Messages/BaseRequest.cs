using System.Collections.Generic;

namespace Farfetch.App.Messages
{
    public abstract class BaseRequest
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public BaseRequest() { }

        /// <summary>
        /// Headers da requisição.
        /// </summary>
        public virtual IDictionary<string, string> DefaultRequestHeaders { get; private set; } = new Dictionary<string, string>();

        /// <summary>
        /// Adicionar mais um item ao header. Caso o valor seja vazio, não será adicionada a chave ao header.
        /// </summary>
        /// <param name="key">Chave que identifica o valor no header</param>
        /// <param name="value">Valor representado pela chave do header</param>
        public virtual void AddHeader(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return;

            if (DefaultRequestHeaders.Contains(new KeyValuePair<string, string>(key, value)))
                return;

            if (!DefaultRequestHeaders.ContainsKey(key))
                DefaultRequestHeaders.Add(key, value);
            else
                DefaultRequestHeaders[key] = value;
        }

        /// <summary>
        /// Obtem valor do header a partir de uma chave.
        /// </summary>
        /// <param name="key">Chave que identifica o valor no header</param>
        /// <returns>Valor do header a partir da chave passada</returns>
        public virtual string GetHeader(string key) => DefaultRequestHeaders.TryGetValue(key, out string outValue) ? outValue : string.Empty;        
    }
}
