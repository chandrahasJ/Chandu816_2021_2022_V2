export interface IPropertyBase {
  id : number;
  name : string;
  price : number | null;
  sellRent : number;
  propertyType: string;
  furnishingType: string;
  builtArea :number | null;
  bhk: number | null;
  city :string;
  readyToMove: number;
  image? : string;
}
