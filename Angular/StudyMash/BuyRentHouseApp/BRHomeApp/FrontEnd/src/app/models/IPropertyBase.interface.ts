export interface IPropertyBase {
  Id : number;
  Name : string;
  Price : number | null;
  SellRent : number;
  PType: string;
  FType: string;
  BuiltArea :number | null;
  BHK: number | null;
  City :string;
  RTM: number;
  Image? : string;
}
