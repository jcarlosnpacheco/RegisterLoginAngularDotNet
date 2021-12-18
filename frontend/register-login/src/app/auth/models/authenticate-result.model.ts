export interface AuthenticateResult {
  user: {
    username: string;
    password: string;
  };
  token: string;
  expires: Date;
}
