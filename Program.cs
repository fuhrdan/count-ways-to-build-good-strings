//*****************************************************************************
//** 2466. Count Ways to Build Good Strings                         leetcode **
//*****************************************************************************

#define MOD 1000000007

int *v;

int solve(int i, int zero, int one)
{
    if (i == 0)
    {
        return 1;
    }

    if (i < 0)
    {
        return 0;
    }

    if (v[i] != -1)
    {
        return v[i];
    }

    v[i] = (solve(i - one, zero, one) + solve(i - zero, zero, one)) % MOD;
    return v[i];
}

int countGoodStrings(int low, int high, int zero, int one)
{
    int maxSize = 100000;
    v = (int *)malloc((maxSize + 1) * sizeof(int));

    if (!v)
    {
        perror("Memory allocation failed");
        return -1;
    }

    for (int i = 0; i <= maxSize; i++)
    {
        v[i] = -1;
    }

    int count = 0;

    for (int i = low; i <= high; i++)
    {
        count = (count + solve(i, zero, one)) % MOD;
    }

    free(v);
    return count;
}