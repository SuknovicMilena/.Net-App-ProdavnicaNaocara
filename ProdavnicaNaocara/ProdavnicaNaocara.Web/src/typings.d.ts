/* SystemJS module definition */
declare var module: NodeModule;

interface INodeModule {
  id: string;
}

interface IKupac {
  id: number;
  naziv: string;
  brojTelefona: string;
  adresaId: number;
  adresaNaziv: string;
  mestoId: number;
  ulicaId: number;
}

interface IMesto {
  id: number;
  naziv: string;
}
interface IUlica {

  id: number;
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
  zahtevId: number;
  zahtevNaziv: string;
}
interface IZahtevZaPonudom {
  id: number;
  katalogNaziv: string;
  kupacId: number;
  kupacNaziv: string;
}
interface IStavkaPonude {
  rbStavkeId: number;
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
