/* SystemJS module definition */
declare var module: NodeModule;

interface INodeModule {
  id: string;
}

interface IKupac {
  id: number;
  naziv: string;
  brojTelefona: string;
  adresaId: string;
  adresaNaziv: string;
  mestoId: number;
}

interface IMesto {
  mestoId: number;
  naziv: string;
}
interface IUlica {

  ulicaId: number;
  mestoId: number;
  mestoNaziv: string;
  naziv: string;

}
interface IAdresa {

  id: number;
  broj: number;
  ulicaId: number;

}
interface IPonuda {
  id: number;
  datum: Date;
  napomena: string;

}

interface IStavkaPonude {
  rb: number;
  ponudaId: number;
  kolicina: number;
  proizvodId: number;
  proizvodNaziv: string;
  statusPonude: number;

}
interface IProizvod {
  id: number;
  ime: string;
}
