import { z } from "zod";
export const LoginSchema = z.object({
    login: z.string().min(3, "login to short"),
    password: z.string().min(8,"password to short")
  });

  export interface UserData 
  {
    login: string;
    avatar: ImageBitmap;
    
  }