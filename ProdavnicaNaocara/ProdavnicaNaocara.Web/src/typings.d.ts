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
