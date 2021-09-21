export interface IUserForRegister
{
    userName : string;
    email? : string;
    password: string;
    mobile?: number;
}

export interface IUserForLoginRequest{
    userName : string;
    password: string;
}

export interface IUserForLoginResponse{
  userName : string;
  token: string;
}
