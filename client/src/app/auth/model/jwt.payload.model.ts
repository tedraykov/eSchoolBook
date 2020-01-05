export interface JwtPayloadModel {
   nameid: string;
   schoolId: string;
   isAdmin: boolean;
   role: string;
   nbf: number
   exp: number
   iat: number
}
