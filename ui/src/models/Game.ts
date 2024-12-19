import { z } from "zod";
export interface Game extends GameCreate {
    id: string;
}
export interface GameCreate {
    name: string;
    teams: number;
    maxPlayersInTeam: number;
}
export const GameSchema = z.object({
    id: z.string(),
    name: z.string(),
    teams: z.number(),
    maxPlayersInTeam: z.number()
  });
  export const GameCreateSchema = z.object({
    name: z.string().min(3, "name to short"),
    teams: z.number().min(2,"teams must be greater than 1"),
    maxPlayersInTeam: z.number().min(1,"max players in team must be greater than 0")
  });