module Main where

import qualified Data.List.Split as Split
import qualified Data.List as List
import Control.Monad as Monad
-- import Control.Monad.Loops as Loops

main :: IO ()
-- main = interact (writeOutput . solve . readInput)
-- main = do
--     countM <- getLine
--     let count :: Int
--         count = read countM
--     let output :: [String]
--         output = []
--     lines <- Monad.replicateM (count) $ do
--         line <- getLine
--         if line == "what does the fox say?" then
--             return ++ (foxSays line)
--         else
--             return ++ line
--     mapM_ (\x -> putStrLn x) $ output
-- main = do
--     ls <- getContents
--     mapM_ print (lines ls)
--     putStrLn (getResult ls)
main = do
    n <- readLn
    cases <- Monad.replicateM (n) $ do
        return . whileM (/= "what does the fox say?") $ (return getLine)
    mapM_ putStrLn (map foxSays cases)

getResult :: String -> String
getResult input = unlines . map (foxSays) . byCase . tail . lines $ input

byCase :: [String] -> [[String]]
byCase input = Split.splitWhen (=="what does the fox say?") input

foxSays :: [String] -> String
foxSays aCase =
    let
        sounds = words (head aCase) -- :: [String]
        claimedSounds = map (last) (map words (tail aCase)) -- :: [String]
    in
        unwords (takeWhile (\x -> not (elem x claimedSounds)) sounds)
{-
interact f = do
  s <- getContents
  putStr (f s)
-}

{-
main :: IO ()
main = do
       putStrLn "Greetings once again.  What is your name?"
       inpStr <- getLine
       let outStr = name2reply inpStr
       putStrLn outStr
-}
