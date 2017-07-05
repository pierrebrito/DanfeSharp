﻿using System;
using System.Xml;
using System.Xml.Serialization;

namespace DanfeSharp.Esquemas
{
    [Serializable]
    [XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
    public class NFReferenciada
    {
        [XmlElement("refCTe", typeof(string))]
        [XmlElement("refECF", typeof(RefECF))]
        [XmlElement("refNF", typeof(RefNF))]
        [XmlElement("refNFP", typeof(RefNFP))]
        [XmlElement("refNFe", typeof(string))]
        [XmlChoiceIdentifier("TipoNFReferenciada")]
        public object Item;

        [XmlIgnore]
        public TipoNFReferenciada TipoNFReferenciada { get; set; }

        public override string ToString()
        {
            if (TipoNFReferenciada == TipoNFReferenciada.refCTe)
                return "CT-e Ref.: " + Formatador.FormatarChaveAcesso(Item.ToString());
            else if (TipoNFReferenciada == TipoNFReferenciada.refNFe)
                return "NF-e Ref.: " + Formatador.FormatarChaveAcesso(Item.ToString());
            else
                return Item.ToString();
        }

    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
    public enum TipoNFReferenciada
    {
        refCTe,
        refECF,
        refNF,
        refNFP,
        refNFe,
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
    public class RefECF
    {
        /// <remarks/>
        public string mod { get; set; }

        /// <remarks/>
        public string nECF { get; set; }

        /// <remarks/>
        public string nCOO { get; set; }

        public override string ToString()
        {
            return $"ECF Ref.: Modelo: {mod} ECF: {nECF} COO: {nCOO}";
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
    public class RefNF
    {
        public string AAMM { get; set; }

        /// <remarks/>
        public string CNPJ { get; set; }

        /// <remarks/>
        public string mod { get; set; }

        /// <remarks/>
        public string serie { get; set; }

        /// <remarks/>
        public string nNF { get; set; }

        public override string ToString()
        {
            return $"NF Ref.: Série: {serie} Número: {nNF} Emitente: {Formatador.FormatarCnpj(CNPJ)} Modelo: {mod}";
        }
    }

    [Serializable]
    [XmlType(AnonymousType = true, Namespace = Namespaces.NFe)]
    public class RefNFP
    {
        /// <remarks/>
        public string AAMM { get; set; }

        public string CNPJ { get; set; }
        public string CPF { get; set; }

        /// <remarks/>
        public string IE { get; set; }

        /// <remarks/>
        public string mod { get; set; }

        /// <remarks/>
        public string serie { get; set; }

        /// <remarks/>
        public string nNF { get; set; }

        public override string ToString()
        {
            String cpfCnpj = !String.IsNullOrWhiteSpace(CNPJ) ? CNPJ : CPF;
            return $"NFP Ref.: Série: {serie} Número: {nNF} Emitente: {Formatador.FormatarCpfCnpj(cpfCnpj)} Modelo: {mod} IE: {IE}";
        }
    }
}
